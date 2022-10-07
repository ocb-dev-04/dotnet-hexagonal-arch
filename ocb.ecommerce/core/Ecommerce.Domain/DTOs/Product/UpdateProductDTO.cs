using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.DTOs;

public sealed class UpdateProductDTO : FlatAuditableDTO
{
    public string Name { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double Price { get; set; }

    public int Stock { get; set; }
}
