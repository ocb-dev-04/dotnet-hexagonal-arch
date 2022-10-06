using AutoMapper;

using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Mappers;

/// <summary>
/// <see cref="Product"/> and <see cref="ProductDTO"/> mappers
/// </summary>
public sealed class ProductMappers : Profile
{
	/// <summary>
	/// <see cref="ProductMappers"/> constructor
	/// </summary>
	public ProductMappers()
	{
		// queries
		CreateMap<Product, ProductDTO>();
		CreateMap<Product, FlatProductDTO>();

		// commands
		CreateMap<CreateProductDTO, Product>();
	}
}
