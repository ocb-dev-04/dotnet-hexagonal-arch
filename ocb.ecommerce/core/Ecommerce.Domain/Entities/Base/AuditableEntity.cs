using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities;

public class AuditableEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CreatorId { get; set; }

    [Required]
    public DateTimeOffset CreateAt { get; set; }

    [Required]
    public DateTimeOffset ModifiedAt { get; set; }
}
