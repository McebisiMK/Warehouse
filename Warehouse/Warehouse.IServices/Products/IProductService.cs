using System.Collections.Generic;
using Warehouse.Entities;

namespace Warehouse.IServices.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}
