using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Enums;

/// <summary>
/// Enums to filter <see cref="Product"/> by price
/// </summary>
public enum PriceFilterOptions
{
    Equal = 0,
    NotEqual,
    GreaterThan,
    LessThan,
}
