using Microsoft.EntityFrameworkCore;

using Ecommerce.Domain.Entities;

namespace Ecommerce.Infraestructure.Relational.Context;

/// <summary>
/// <see cref="DbContext"/> main class
/// </summary>
public sealed class MainDbContext : DbContext
{
	#region Ctor

	/// <summary>
	/// <see cref="MainDbContext"/> constructor
	/// </summary>
	/// <param name="options"></param>
	public MainDbContext(DbContextOptions<MainDbContext> options)
		:base(options)
	{

	}

	#endregion

	#region DbSet's

	/// <summary>
	/// <see cref="Product"/> database table representation
	/// </summary>
	public DbSet<Product> Products { get; set; }

	#endregion
}
