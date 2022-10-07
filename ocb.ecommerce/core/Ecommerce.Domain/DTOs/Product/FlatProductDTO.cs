namespace Ecommerce.Domain.DTOs;

public sealed class FlatProductDTO : FlatAuditableDTO
{
    public string Name { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public double Price { get; set; }

}
