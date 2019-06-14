using System.ComponentModel.Composition;
using Warehouse.IRepositories.Products;
using Warehouse.IRepositories.Suppliers;
using Warehouse.Repositories.Products;
using Warehouse.Repositories.Suppliers;
using Warehouse.Resolver;

namespace Warehouse.Repositories.Resolutions
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IProductRepository, ProductRepository>();
            registerComponent.RegisterType<ISupplierRepository, SupplierRepository>();
        }
    }
}
