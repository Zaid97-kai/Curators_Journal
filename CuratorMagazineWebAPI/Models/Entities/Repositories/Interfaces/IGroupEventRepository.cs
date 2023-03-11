using Shared.Entities.Domains;

namespace API.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IEventRepository
/// Extends the <see cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.GroupEvent}" />
/// </summary>
/// <seealso cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.GroupEvent}" /
public interface IGroupEventRepository : IBaseRepository<GroupEvent>
{
}

