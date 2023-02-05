using API.Models.Entities.Repositories.Interfaces;
using Shared.Bases.Interfaces.IHaves;

namespace API.Models.Bases.IBases;

/// <summary>
/// Interface IBaseRepositoryHaveDto
/// Extends the <see cref="IBaseRepository{TDomain}" />
/// </summary>
/// <typeparam name="TDomain">The type of the t domain.</typeparam>
/// <typeparam name="TDto">The type of the t dto.</typeparam>
/// <seealso cref="IBaseRepository{TDomain}" />
public interface IBaseRepositoryHaveDto<TDomain, TDto> : IBaseRepository<TDomain>
        where TDomain : class, IHaveId
        where TDto : class, new()
{
    /// <summary>
    /// Gets all dto.
    /// </summary>
    /// <returns>Task&lt;List&lt;TDto&gt;&gt;.</returns>
    Task<List<TDto>> GetAllDto();

    /// <summary>
    /// Gets the dto by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;TDto&gt;.</returns>
    Task<TDto> GetDtoById(int id);
    /// <summary>
    /// Gets the dtos by ids.
    /// </summary>
    /// <param name="ids">The ids.</param>
    /// <returns>Task&lt;List&lt;TDto&gt;&gt;.</returns>
    Task<List<TDto>> GetDtosByIds(string[] ids);

    /// <summary>
    /// Creates the dto by.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;TDto&gt;.</returns>
    Task<TDto> CreateDtoBy(int id);
    /// <summary>
    /// Creates the by.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;TDomain&gt;.</returns>
    Task<TDomain> CreateBy(int id);

    /// <summary>
    /// Saves the dto.
    /// </summary>
    /// <typeparam name="TDtoData">The type of the t dto data.</typeparam>
    /// <param name="dtoData">The dto data.</param>
    /// <returns>Task&lt;TDto&gt;.</returns>
    Task<TDto> SaveDto<TDtoData>(TDtoData dtoData)
        where TDtoData : IHaveId;

    /// <summary>
    /// Reorders the specified dto datas.
    /// </summary>
    /// <typeparam name="TDtoData">The type of the t dto data.</typeparam>
    /// <param name="dtoDatas">The dto datas.</param>
    /// <returns>Task&lt;List&lt;TDto&gt;&gt;.</returns>
    Task<List<TDto>> Reorder<TDtoData>(IEnumerable<TDtoData> dtoDatas)
        where TDtoData : IHaveId;
}