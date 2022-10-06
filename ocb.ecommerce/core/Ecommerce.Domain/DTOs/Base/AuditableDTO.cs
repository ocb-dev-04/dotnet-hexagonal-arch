namespace Ecommerce.Domain.DTOs;

/// <summary>
/// <see cref="AuditableDTO"/> class
/// </summary>
public class AuditableDTO : FlatAuditableDTO
{
    /// <summary>
    /// DTO creation date 
    /// </summary>
    public DateTimeOffset CreateAt { get; set; }

    /// <summary>
    /// DTO modification date 
    /// </summary>
    public DateTimeOffset ModifiedAt { get; set; }
}
