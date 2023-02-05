using API.Models.Entities.Domains;

namespace API.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IRoleRepository
/// Extends the <see cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.Role}" />
/// </summary>
/// <seealso cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.Role}" />
public interface IRoleRepository : IBaseRepository<Role>
{
    
}