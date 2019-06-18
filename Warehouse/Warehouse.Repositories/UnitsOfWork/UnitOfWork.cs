using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.IRepositories.UnitsOfWork;

namespace Warehouse.Repositories.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private WarehouseEntities _context;
        private DbContextTransaction _dbContextTransaction;

        public UnitOfWork()
        {
            _context = new WarehouseEntities();
            _context.Configuration.LazyLoadingEnabled = false;
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var exceptionMessage = ExceptionHandler(ex);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();

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
                this._dbContextTransaction = _context.Database.BeginTransaction();
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
            return _context.SaveChangesAsync();
        }

        public void RollbackTransaction()
        {
            _dbContextTransaction.Rollback();
        }
    }
}
