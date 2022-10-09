using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using AutoMapper;
using Ardalis.GuardClauses;

using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infraestructure.Relational.Context;

using Shared.Common.Sources.Extensions;

namespace Ecommerce.Infraestructure.Relational.Implementations;

public sealed class GenericRepository<Entity, DTO> 
    : BaseRepository, IDisposable, IGenericRepository<Entity, DTO>
    where Entity : AuditableEntity
    where DTO : FlatAuditableDTO
{
    #region Ctor

    private readonly DbSet<Entity> _table;
    private readonly IMapper _mapper;
    private const int pageGrow = 20;

    public GenericRepository(MainDbContext context, IMapper mapper)
        : base(context, mapper)
    {
        _table = _context.Set<Entity>();
        _mapper = Guard.Against.Null(mapper, nameof(mapper));
    }

    #endregion

    #region Queries

    public async Task<Entity> GetById(Guid id)
        => await _table.FindAsync(id);

    public async Task<HashSet<DTO>> GetCollection(int pageNumber)
    {
        IEnumerable<Entity> list = await _table.AsQueryable().Paginate(pageNumber, pageGrow).ToListAsync();
        return _mapper.Map<HashSet<DTO>>(list.ToHashSet());
    }

    #endregion

    #region Commands

    public async Task<Entity> Create(Entity model)
    {
        EntityEntry<Entity> entity = await _table.AddAsync(model);
        return entity.Entity;
    }

    public async Task Update(Entity model)
    {
        Entity finded = await _table.FindAsync(model.Id);
        _context.Entry(finded).CurrentValues.SetValues(model);
    }

    public async Task Delete(Guid id)
    {
        Entity finded = await _table.FindAsync(id);
        _table.Remove(finded);
    }

    #endregion

    #region Dispose method

    public void Dispose()
    {
        if (_context is not null)
            _context.Dispose();
    }

    #endregion
}
