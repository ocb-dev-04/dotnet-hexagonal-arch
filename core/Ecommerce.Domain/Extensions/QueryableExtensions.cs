using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<Product> FilterByPrice(this IQueryable<Product> query, double price, PriceFilterOptions filterOptions)
        => filterOptions switch
        {
            PriceFilterOptions.Equal => query.Where(w => w.Price.Equals(price)),
            PriceFilterOptions.NotEqual => query.Where(w => !w.Price.Equals(price)),
            PriceFilterOptions.GreaterThan => query.Where(w => w.Price > price),
            PriceFilterOptions.LessThan => query.Where(w => w.Price < price),
            _ => query
        };
}
