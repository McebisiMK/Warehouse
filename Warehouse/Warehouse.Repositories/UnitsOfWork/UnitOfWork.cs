using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.IRepositories.Products;
using Warehouse.IRepositories.Suppliers;
using Warehouse.IRepositories.UnitsOfWork;
using Warehouse.Repositories.Products;
using Warehouse.Repositories.Suppliers;

namespace Warehouse.Repositories.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private WarehouseEntities context;
        private DbContextTransaction _dbContextTransaction;

        private IProductRepository productRepository;
        private ISupplierRepository supplierRepository;

        public UnitOfWork()
        {
            context = new WarehouseEntities();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
        }

        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var exceptionMessage = ExceptionHandler(ex);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private bool disposed = false;

        public IProductRepository ProductRepository
        {
            get { return productRepository ?? new ProductRepository(context); }
        }

        public ISupplierRepository SupplierRepository
        {
            get { return supplierRepository ?? new SupplierRepository(context); }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();

                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            if (_dbContextTransaction == null)
            {
                this._dbContextTransaction = context.Database.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            try
            {
                _dbContextTransaction.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var exceptionMessage = ExceptionHandler(ex);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private string ExceptionHandler(DbEntityValidationException ex)
        {
            // Retrieve the error messages as a list of strings.
            var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
            // Join the list to a single string.
            var fullErrorMessage = string.Join("; ", errorMessages);
            // Combine the original exception message with the new one.
            return string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public void RollbackTransaction()
        {
            _dbContextTransaction.Rollback();
        }
    }
}
