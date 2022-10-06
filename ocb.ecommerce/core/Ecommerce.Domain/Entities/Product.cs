using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities;

public sealed class Product : AuditableEntity
{
    [Required, MinLength(5), MaxLength(40)]
    public string Name { get; set; }

    [Required,MaxLength(200)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public double Price { get; set; }
}
