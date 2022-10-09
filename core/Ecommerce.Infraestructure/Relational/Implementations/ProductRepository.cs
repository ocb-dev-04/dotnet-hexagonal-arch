using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Extensions;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infraestructure.Relational.Context;

namespace Ecommerce.Infraestructure.Relational.Implementations;

public sealed class ProductRepository : BaseRepository, IProductRepository
{
	#region Ctor

	public ProductRepository(MainDbContext context, IMapper mapper) 
		: base(context, mapper)
	{}

    #endregion

    public async Task<HashSet<FlatProductDTO>> GetByPrice(double price, PriceFilterOptions filterOption)
    {
        List<FlatProductDTO> collection = await _context.Products
                                    .AsNoTracking()
                                    .FilterByPrice(price, filterOption)
                                    .ProjectTo<FlatProductDTO>(_mapper.ConfigurationProvider)
                                    .ToListAsync();

        return collection.ToHashSet();
    }
}
