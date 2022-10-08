using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Interfaces;

public interface IProductRepository
{
    Task<HashSet<FlatProductDTO>> GetByPrice(double price, PriceFilterOptions filterOption);
}
