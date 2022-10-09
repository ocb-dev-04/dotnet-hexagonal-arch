using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IUnitOfWork
{
    #region Specific repositories

    public IProductRepository ProductSpecificRepository { get; }

    #endregion

    #region Generic repositories

    public IGenericRepository<Product, ProductDTO> ProductGenericRepository { get; }
    public IGenericRepository<Product, FlatProductDTO> FlatProductGenericRepository { get; }
   
    #endregion

    Task<bool> Commit();
}
