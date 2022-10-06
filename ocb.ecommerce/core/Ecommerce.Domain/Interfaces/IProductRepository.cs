using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Interfaces;

/// <summary>
/// Contracts to <see cref="Product"/> repository
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Get a <see cref="Product"/> collection by max or min price
    /// </summary>
    /// <param name="price"></param>
    /// <param name="maxOrMin"></param>
    /// <returns></returns>
    Task<HashSet<Product>> GetByPrice(double price, PriceFilterOptions filterOption);

}
