using Warehouse.Entities;
using Warehouse.GenericRepository;
using Warehouse.IRepositories.Suppliers;

namespace Warehouse.Repositories.Suppliers
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private WarehouseEntities context;

        public SupplierRepository(WarehouseEntities context) : base(context)
        {
            this.context = context;
        }
    }
}
