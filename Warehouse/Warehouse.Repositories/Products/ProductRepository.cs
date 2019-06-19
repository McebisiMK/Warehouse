using System.Collections.Generic;
using System.Linq;
using Warehouse.Entities;
using Warehouse.GenericRepository;
using Warehouse.IRepositories.Products;

namespace Warehouse.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private WarehouseEntities context;

        public ProductRepository(WarehouseEntities context): base(context)
        {
            this.context = context;
        }
    }
}
