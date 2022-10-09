using AutoMapper;

using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Mappers;

public sealed class ProductMappers : Profile
{
	public ProductMappers()
	{
		// queries
		CreateMap<Product, ProductDTO>();
		CreateMap<Product, FlatProductDTO>();

		// commands
		CreateMap<CreateProductDTO, Product>();
	}
}
