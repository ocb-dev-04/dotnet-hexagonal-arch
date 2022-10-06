using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infraestructure.Relational.Context;

using Shared.Common.Sources.Extensions;

namespace Ecommerce.Infraestructure.Relational.Implementations;

/// <summary>
/// <see cref="IGenericRepository{Entity}"/> implementation
/// </summary>
/// <typeparam name="Entity"></typeparam>
public sealed class GenericRepository<Entity> 
    : BaseRepository, IDisposable, IGenericRepository<Entity>
    where Entity : AuditableEntity
{
    #region Ctor

    private readonly DbSet<Entity> _table;
    private const int pageGrow = 20;

    /// <summary>
    /// <see cref="GenericRepository{Entity}"/> contructor
    /// </summary>
    public GenericRepository(MainDbContext context)
        : base(context)
    {
        _table = _context.Set<Entity>();
    }

    #endregion

    #region Queries

    /// <inheritdoc/>
    public async Task<Entity> GetById(Guid id)
        => await _table.FindAsync(id);

    /// <inheritdoc/>
    public async Task<HashSet<Entity>> GetCollection(int pageNumber)
    {
        IEnumerable<Entity> list = await _table.AsQueryable().Paginate(pageNumber, pageGrow).ToListAsync();
        return list.ToHashSet();
    }

    #endregion

    #region Commands

    /// <inheritdoc/>
    public async Task<Entity> Create(Entity model)
    {
        EntityEntry<Entity> entity = await _table.AddAsync(model);
        return entity.Entity;
    }

    /// <inheritdoc/>
    public async Task Update(Entity model)
    {
        Entity finded = await _table.FindAsync(model.Id);
        _context.Entry(finded).CurrentValues.SetValues(model);
    }

    /// <inheritdoc/>
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
