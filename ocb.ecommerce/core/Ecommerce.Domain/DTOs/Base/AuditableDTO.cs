namespace Ecommerce.Domain.DTOs;

public class AuditableDTO : FlatAuditableDTO
{
    public DateTimeOffset Created { get; set; }

    public DateTimeOffset Modified { get; set; }
}
