using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces;

/// <summary>
/// <see cref="IUnitOfWork"/> has all contract to implement into UnitOfwork class
/// </summary>
public interface IUnitOfWork
{
    #region Specific repositories

    public IProductRepository ProductSpecificRepository { get; }

    #endregion

    #region Generic repositories

    public IGenericRepository<Product> ProductGenericRepository { get; }
   
    #endregion

    /// <summary>
    /// Save all data
    /// </summary>
    /// <returns></returns>
    Task<bool> Commit();
}
