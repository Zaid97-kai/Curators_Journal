using Shared.Entities.Domains;

namespace API.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IEventRepository
/// Extends the <see cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.Event}" />
/// </summary>
/// <seealso cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.Event}" /
public interface IEventRepository : IBaseRepository<Event>
{
}
