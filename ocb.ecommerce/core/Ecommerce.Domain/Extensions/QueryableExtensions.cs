using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Extensions;

/// <summary>
/// <see cref="IQueryable"/> Extensions methods to make more easy filter and search. Here there are only Repository extension methods.
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Filter <see cref="Product"/> by pricc
    /// </summary>
    /// <param name="query"></param>
    /// <param name="price"></param>
    /// <param name="filterOptions"></param>
    /// <returns></returns>
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
