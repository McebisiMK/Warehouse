using System.Collections.Generic;
using System.Linq;
using Warehouse.Entities;
using Warehouse.IRepositories.Products;

namespace Warehouse.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            using (var dbContext = new WarehouseEntities())
            {
                var products = dbContext.Products;

                return products.ToList();
            }
        }
    }
}
