using API.Models.Bases.Filters;
using API.Models.Context;
using API.Models.Entities.Domains;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Bases.Dtos.BaseHelpers;
using X.PagedList;

namespace API.Models.Entities.Repositories.Entities;

/// <summary>
/// Class UserRepository.
/// Implements the <see cref="API.Models.Entities.Repositories.Entities.BaseRepository{API.Models.Entities.Domains.User}" />
/// Implements the <see cref="IUserRepository" />
/// </summary>
/// <seealso cref="API.Models.Entities.Repositories.Entities.BaseRepository{API.Models.Entities.Domains.User}" />
/// <seealso cref="IUserRepository" />
public class UserRepository : BaseRepository<User>, IUserRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UserRepository(CuratorMagazineContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets the list.
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>Task&lt;BaseDtoListResult&gt;.</returns>
    public override async Task<BaseDtoListResult> GetList(BaseFilterGetList filter)
    {
        var ret = GetQueue(filter)
            .Include(w => w.Role)
                .ThenInclude(d => d!.Users)
            .Include(w => w.Division)
                .ThenInclude(d => d!.Users)
            .ToPagedListAsync(filter.page, 300).Result;

        var items = ret.Select(s => s);

        return new BaseDtoListResult
        {
            Items = items,
            PageCount = items.PageCount
        };
    }

    /// <summary>
    /// Gets the queue.
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>IQueryable&lt;User&gt;.</returns>
    protected override IQueryable<User> GetQueue(BaseFilterGetList filter)
    {
        var queue = Context.Users.AsQueryable();

        var queries = (filter.query ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        queue = queries.Aggregate(queue, (current, q) => current.Where(w => EF.Functions.ILike(w.Name, $"%{q}%")));

        if (filter.groupId != null)
        {
            queue = queue.Where(u => u.GroupId == filter.groupId);
        }

        queue = queue.OrderBy(o => o.Name);
        return queue;
    }
}