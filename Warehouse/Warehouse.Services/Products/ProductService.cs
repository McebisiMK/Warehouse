using Warehouse.IRepositories.UnitsOfWork;
using Warehouse.IServices.Products;

namespace Warehouse.Services.Products
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
