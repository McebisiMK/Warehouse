using System.ComponentModel.Composition;
using Warehouse.IServices.Products;
using Warehouse.IServices.Suppliers;
using Warehouse.Resolver;
using Warehouse.Services.Products;
using Warehouse.Services.Suppliers;

namespace Warehouse.Services.Resoulutions
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IProductService, ProductService>();
            registerComponent.RegisterType<ISupplierService, SupplierService>();
        }
    }
}
