using System;
using Warehouse.IRepositories.Products;
using Warehouse.IRepositories.Suppliers;

namespace Warehouse.IRepositories.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        int SaveChanges();
    }
}
