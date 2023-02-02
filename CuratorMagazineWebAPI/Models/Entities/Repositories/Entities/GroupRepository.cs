// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 12-19-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-25-2022
// ***********************************************************************
// <copyright file="GroupRepository.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using CuratorMagazineWebAPI.Models.Bases.Filters;
using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Bases.Dtos.BaseHelpers;
using X.PagedList;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;

/// <summary>
/// Class GroupRepository.
/// Implements the <see cref="BaseRepository{T}.Models.Entities.Group}" />
/// Implements the <see cref="IGroupRepository" />
/// </summary>
/// <seealso cref="BaseRepository{T}.Models.Entities.Group}" />
/// <seealso cref="IGroupRepository" />
public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GroupRepository" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public GroupRepository(CuratorMagazineContext context) : base(context)
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
    protected override IQueryable<Group> GetQueue(BaseFilterGetList filter)
    {
        var queue = Context.Groups.AsQueryable();

        var queries = (filter.query ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        queue = queries.Aggregate(queue, (current, q) => current.Where(w => EF.Functions.ILike(w.Name, $"%{q}%")));

        queue = queue.OrderBy(o => o.Name);
        return queue;
    }
}