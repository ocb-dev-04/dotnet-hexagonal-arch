using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infraestructure.Relational.Context;

namespace Ecommerce.Infraestructure.Relational.Implementations;

/// <summary>
/// <see cref="IUnitOfWork"/> implementation
/// </summary>
public sealed class UnitOfWork : BaseRepository, IUnitOfWork
{
    #region Properties & Ctor

    #region Specific props

    private readonly IProductRepository _productSpecificRepository;

    #endregion

    #region Generic props

    private readonly IGenericRepository<Product> _productGenericRepository;
   
    #endregion

    /// <summary>
    /// <see cref="UnitOfWork"/> constructor
    /// </summary>
    /// <param name="context"></param>
    public UnitOfWork(MainDbContext context) : base(context)
    {

    }

    #endregion

    #region Specific repositories

    public IProductRepository ProductSpecificRepository => _productSpecificRepository ?? new ProductRepository(_context);
    
    #endregion

    #region Generic repositories

    public IGenericRepository<Product> ProductGenericRepository => _productGenericRepository ?? new GenericRepository<Product>(_context);
   
    #endregion

    /// <inheritdoc/>
    public async Task<bool> Commit()
    {
        int changes = await _context.SaveChangesAsync();
        return changes > 0;
    }
}
