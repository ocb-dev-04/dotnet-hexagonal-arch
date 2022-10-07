using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IUnitOfWork
{
    #region Specific repositories

    public IProductRepository ProductSpecificRepository { get; }

    #endregion

    #region Generic repositories

    public IGenericRepository<Product> ProductGenericRepository { get; }
   
    #endregion

    Task<bool> Commit();
}
