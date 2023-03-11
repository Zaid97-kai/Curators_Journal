using System.Linq.Expressions;
using API.Models.Bases.Filters;
using API.Models.Entities.Repositories.Interfaces;
using Persistence.Context;
using Shared.Bases.Dtos.BaseHelpers;

namespace API.Models.Entities.Repositories.Entities;

/// <summary>
/// Class BaseRepository.
/// Implements the <see cref="IBaseRepository{T}" />
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="IBaseRepository{T}" />
public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    /// <summary>
    /// The context
    /// </summary>
    protected readonly CuratorMagazineContext Context;

    /// <summary>
    /// Gets the list.
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>Task&lt;BaseDtoListResult&gt;.</returns>
    public abstract Task<BaseDtoListResult> GetList(BaseFilterGetList filter);

    /// <summary>
    /// Gets the queue.
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>IQueryable&lt;User&gt;.</returns>
    protected abstract IQueryable<T> GetQueue(BaseFilterGetList filter);

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository{T}" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    protected BaseRepository(CuratorMagazineContext context)
    {
        Context = context;
    }

    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    public async Task Add(T entity)
    {
        Context.Set<T>().Add(entity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    public async Task Update(T entity)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Finds the specified expression.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().Where(expression);
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>T.</returns>
    public async Task<T?> GetById(int id)
    {
        return Context.Set<T>().Find(id);
    }

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    public async Task Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
    }
}