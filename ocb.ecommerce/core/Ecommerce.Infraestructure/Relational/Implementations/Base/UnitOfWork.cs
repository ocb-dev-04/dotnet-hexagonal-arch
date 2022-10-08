using AutoMapper;

using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infraestructure.Relational.Context;

namespace Ecommerce.Infraestructure.Relational.Implementations;

public sealed class UnitOfWork : BaseRepository, IUnitOfWork
{
    #region Properties & Ctor

    #region Specific props

    private readonly IProductRepository _productSpecificRepository;

    #endregion

    #region Generic props

    private readonly IGenericRepository<Product, ProductDTO> _productGenericRepository;
    private readonly IGenericRepository<Product, FlatProductDTO> _flatProductGenericRepository;

    #endregion

    #endregion

    #region Ctor

    public UnitOfWork(MainDbContext context, IMapper mapper) 
        : base(context, mapper)
    {}

    #endregion

    #region Specific repositories

    public IProductRepository ProductSpecificRepository => _productSpecificRepository ?? new ProductRepository(_context);
    
    #endregion

    #region Generic repositories

    public IGenericRepository<Product, ProductDTO> ProductGenericRepository => _productGenericRepository ?? new GenericRepository<Product, ProductDTO>(_context, _mapper);
    public IGenericRepository<Product, FlatProductDTO> FlatProductGenericRepository => _flatProductGenericRepository ?? new GenericRepository<Product, FlatProductDTO>(_context, _mapper);
   
    #endregion

    public async Task<bool> Commit()
    {
        int changes = await _context.SaveChangesAsync();
        return changes > 0;
    }
}
