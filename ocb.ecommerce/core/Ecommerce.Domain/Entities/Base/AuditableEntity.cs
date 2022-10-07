using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities;

public class AuditableEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTimeOffset Created { get; set; }

    [Required]
    public DateTimeOffset Modified { get; set; }
}
