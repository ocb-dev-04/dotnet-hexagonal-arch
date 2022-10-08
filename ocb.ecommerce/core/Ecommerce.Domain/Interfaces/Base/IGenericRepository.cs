using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IGenericRepository<Entity, DTO> 
    where Entity : AuditableEntity
    where DTO : FlatAuditableDTO
{
    #region Queries

    Task<Entity> GetById(Guid id);

    Task<HashSet<DTO>> GetCollection(int pageNumber);

    #endregion

    #region Commands

    Task<Entity> Create(Entity model);

    Task Update(Entity model);

    Task Delete(Guid id);

    #endregion
}
