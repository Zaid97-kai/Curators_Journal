using API.Models.Entities.Domains;

namespace API.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IGroupRepository
/// Extends the <see cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.Group}" />
/// </summary>
/// <seealso cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.Group}" />
public interface IGroupRepository : IBaseRepository<Group>
{
    
}