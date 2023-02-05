using System.Linq.Expressions;
using API.Models.Bases.Filters;
using Shared.Bases.Dtos.BaseHelpers;

namespace API.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IBaseRepository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBaseRepository<T> where T : class
{
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>T.</returns>
    Task<T?> GetById(int id);

    /// <summary>
    /// Gets the list.
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>Task&lt;BaseDtoListResult&gt;.</returns>
    Task<BaseDtoListResult> GetList(BaseFilterGetList filter);

    /// <summary>
    /// Finds the specified expression.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);

    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    Task Add(T entity);

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    Task Update(T entity);

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    Task Remove(T entity);
}