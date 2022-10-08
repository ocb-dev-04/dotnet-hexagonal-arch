using Microsoft.EntityFrameworkCore;

using Ecommerce.Domain.Entities;

namespace Ecommerce.Infraestructure.Relational.Context;

public sealed class MainDbContext : DbContext
{
	#region Ctor

	
	public MainDbContext(DbContextOptions<MainDbContext> options)
		:base(options)
	{

	}

	#endregion

	#region DbSet's

	public DbSet<Product> Products { get; set; }

	#endregion
}
