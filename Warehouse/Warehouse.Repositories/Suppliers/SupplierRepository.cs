using System.Collections.Generic;
using System.Linq;
using Warehouse.Entities;
using Warehouse.IRepositories.Suppliers;

namespace Warehouse.Repositories.Suppliers
{
    public class SupplierRepository : ISupplierRepository
    {
        private WarehouseEntities context;

        public SupplierRepository(WarehouseEntities context)
        {
            this.context = context;
        }
    }
}
