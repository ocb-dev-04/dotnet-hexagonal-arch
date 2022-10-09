using AutoMapper;
using Ardalis.GuardClauses;

using Ecommerce.Infraestructure.Relational.Context;

namespace Ecommerce.Infraestructure.Relational.Implementations;

public class BaseRepository
{
    protected readonly MainDbContext _context;
	protected readonly IMapper _mapper;

	public BaseRepository(MainDbContext context, IMapper mapper)
	{
		this._context = Guard.Against.Null(context, nameof(context));
		this._mapper = Guard.Against.Null(mapper, nameof(mapper));
	}
}
