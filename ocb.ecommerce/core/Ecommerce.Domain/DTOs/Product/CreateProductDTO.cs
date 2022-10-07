namespace Ecommerce.Domain.DTOs;

public sealed class CreateProductDTO
{
    public string Name { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double Price { get; set; }

    public int Stock { get; set; }
}
