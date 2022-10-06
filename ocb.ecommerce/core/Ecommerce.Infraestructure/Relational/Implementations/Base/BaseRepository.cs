using Ardalis.GuardClauses;

using Ecommerce.Infraestructure.Relational.Context;

namespace Ecommerce.Infraestructure.Relational.Implementations;

/// <summary>
/// <see cref="BaseRepository"/> inheritable class to use in specific repositories
/// </summary>
public class BaseRepository
{
    protected readonly MainDbContext _context;

	/// <summary>
	/// <see cref="BaseRepository"/> constructor
	/// </summary>
	/// <param name="context"></param>
	public BaseRepository(MainDbContext context)
	{
		this._context = Guard.Against.Null(context, nameof(context));
	}
}
