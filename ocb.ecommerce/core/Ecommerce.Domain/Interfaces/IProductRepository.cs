using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IProductRepository
{
    Task<HashSet<Product>> GetByPrice(double price, PriceFilterOptions filterOption);
}
