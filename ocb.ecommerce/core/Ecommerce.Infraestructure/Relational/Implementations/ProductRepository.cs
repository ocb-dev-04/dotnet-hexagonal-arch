using Ecommerce.Domain.Interfaces;
using Ecommerce.Infraestructure.Relational.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infraestructure.Relational.Implementations;

public sealed class ProductRepository : BaseRepository, IProductRepository
{
	#region Ctor

	public ProductRepository(MainDbContext context) 
		: base(context)
	{
	}

	#endregion
}
