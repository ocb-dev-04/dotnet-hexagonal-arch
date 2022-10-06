using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

/// <summary>
/// <see cref="Entity"/> generic repository contracts
/// </summary>
/// <typeparam name="Entity"></typeparam>
public interface IGenericRepository<Entity> 
    where Entity : AuditableEntity
{
    #region Queries

    /// <summary>
    /// Get <see cref="Entity"/> by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Entity> GetById(Guid id);

    /// <summary>
    /// Get <see cref="Entity"/> collection paginated
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    Task<HashSet<Entity>> GetCollection(int pageNumber);

    #endregion

    #region Commands

    /// <summary>
    /// Create a new <see cref="Entity"/>
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<Entity> Create(Entity model);

    /// <summary>
    /// Update an <see cref="Entity"/>
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task Update(Entity model);

    /// <summary>
    /// Delete an <see cref="Entity"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task Delete(Guid id);

    #endregion
}
