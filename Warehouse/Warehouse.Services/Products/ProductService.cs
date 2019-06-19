using System.Collections.Generic;
using Warehouse.Entities;
using Warehouse.IRepositories.Products;
using Warehouse.IServices.Products;

namespace Warehouse.Services.Products
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
    }
}
