using API.Models.Bases.Filters;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Entities.Domains;
using X.PagedList;

namespace API.Models.Entities.Repositories.Entities
{
    public class GroupEventRepository : BaseRepository<GroupEvent>, IGroupEventRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GroupEventRepository(CuratorMagazineContext context) : base(context)
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
                .Include(w => w.Group)
                    .ThenInclude(d => d!.Users)
                .Include(w => w.Event)
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
        protected override IQueryable<GroupEvent> GetQueue(BaseFilterGetList filter)
        {
            var queue = Context.GroupEvents.AsQueryable();

            var queries = (filter.query ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
            if(filter.groupId != null)
            {
                queue = queries.Aggregate(queue, (current, q) => current.Where(w => w.GroupId == filter.groupId));
            }


            queue = queue.OrderBy(o => o.GroupId);
            return queue;
        }
    }
}
