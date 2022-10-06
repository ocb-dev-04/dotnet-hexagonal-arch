using Microsoft.EntityFrameworkCore;

using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Extensions;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infraestructure.Relational.Context;

namespace Ecommerce.Infraestructure.Relational.Implementations;

/// <summary>
/// <see cref="IProductRepository"/> implementation
/// </summary>
public sealed class ProductRepository : BaseRepository, IProductRepository
{
	#region Ctor

	public ProductRepository(MainDbContext context) 
		: base(context)
	{
	}

    #endregion

    /// <inheritdoc/>
    public async Task<HashSet<Product>> GetByPrice(double price, PriceFilterOptions filterOption)
    {
        List<Product> collection = await _context.Products
                                    .AsNoTracking()
                                    .FilterByPrice(price, filterOption)
                                    .ToListAsync();

        return collection.ToHashSet();
    }
}
