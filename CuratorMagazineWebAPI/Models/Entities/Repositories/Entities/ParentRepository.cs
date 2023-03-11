using API.Models.Bases.Filters;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Entities.Domains;
using X.PagedList;

namespace API.Models.Entities.Repositories.Entities;

/// <summary>
/// Class ParentRepository.
/// Implements the <see cref="API.Models.Entities.Repositories.Entities.BaseRepository{API.Models.Entities.Domains.Parent}" />
/// Implements the <see cref="IParentRepository" />
/// </summary>
/// <seealso cref="API.Models.Entities.Repositories.Entities.BaseRepository{API.Models.Entities.Domains.Parent}" />
/// <seealso cref="IParentRepository" />
public class ParentRepository : BaseRepository<Parent>, IParentRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParentRepository" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public ParentRepository(CuratorMagazineContext context) : base(context)
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
            .Include(w => w.FatherChildrens)
            .Include(w => w.MotherChildrens)
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
    protected override IQueryable<Parent> GetQueue(BaseFilterGetList filter)
    {
        var queue = Context.Parents.AsQueryable();

        var queries = (filter.query ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        queue = queries.Aggregate(queue, (current, q) => current.Where(w => EF.Functions.ILike(w.Name, $"%{q}%")));

        queue = queue.OrderBy(o => o.Name);
        return queue;
    }
}