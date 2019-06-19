using System.ComponentModel.Composition;
using Warehouse.IRepositories.UnitsOfWork;
using Warehouse.Repositories.UnitsOfWork;
using Warehouse.Resolver;

namespace Warehouse.Repositories.Resolutions
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}
