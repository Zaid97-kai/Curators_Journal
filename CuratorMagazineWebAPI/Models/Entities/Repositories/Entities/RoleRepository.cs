using API.Models.Bases.Filters;
using API.Models.Context;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Entities.Domains;
using X.PagedList;

namespace API.Models.Entities.Repositories.Entities;

/// <summary>
/// Class RoleRepository.
/// Implements the <see cref="API.Models.Entities.Repositories.Entities.BaseRepository{API.Models.Entities.Domains.Role}" />
/// Implements the <see cref="IRoleRepository" />
/// </summary>
/// <seealso cref="API.Models.Entities.Repositories.Entities.BaseRepository{API.Models.Entities.Domains.Role}" />
/// <seealso cref="IRoleRepository" />
public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleRepository" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public RoleRepository(CuratorMagazineContext context) : base(context)
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
            .Include(w => w.Users)
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
    protected override IQueryable<Role> GetQueue(BaseFilterGetList filter)
    {
        var queue = Context.Roles.AsQueryable();

        var queries = (filter.query ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        queue = queries.Aggregate(queue, (current, q) => current.Where(w => EF.Functions.ILike(w.Name, $"%{q}%")));

        queue = queue.OrderBy(o => o.Name);
        return queue;
    }
}