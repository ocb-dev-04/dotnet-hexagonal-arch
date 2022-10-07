using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IGenericRepository<Entity> 
    where Entity : AuditableEntity
{
    #region Queries

    Task<Entity> GetById(Guid id);

    Task<HashSet<Entity>> GetCollection(int pageNumber);

    #endregion

    #region Commands

    Task<Entity> Create(Entity model);

    Task Update(Entity model);

    Task Delete(Guid id);

    #endregion
}
