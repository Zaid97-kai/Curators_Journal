using API.Models.Entities.Domains;

namespace API.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IParentRepository
/// Extends the <see cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.Parent}" />
/// </summary>
/// <seealso cref="API.Models.Entities.Repositories.Interfaces.IBaseRepository{API.Models.Entities.Domains.Parent}" />
public interface IParentRepository : IBaseRepository<Parent>
{
    
}