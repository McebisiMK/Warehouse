using System.Collections.Generic;
using Warehouse.Entities;

namespace Warehouse.IRepositories.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
