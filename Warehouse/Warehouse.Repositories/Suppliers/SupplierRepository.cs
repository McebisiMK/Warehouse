using System.Collections.Generic;
using System.Linq;
using Warehouse.Entities;
using Warehouse.IRepositories.Suppliers;

namespace Warehouse.Repositories.Suppliers
{
    public class SupplierRepository : ISupplierRepository
    {
        private WarehouseEntities dbContext;

        public SupplierRepository()
        {
            dbContext = new WarehouseEntities();
        }

        public int Add(Supplier supplier)
        {
            dbContext.Suppliers.Add(supplier);

            return dbContext.SaveChanges();
        }

        public IEnumerable<Supplier> GetAll()
        {
            var suppliers = dbContext.Suppliers;

            return suppliers.ToList();
        }
    }
}
