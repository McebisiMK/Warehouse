using Warehouse.IRepositories.UnitsOfWork;
using Warehouse.IServices.Suppliers;

namespace Warehouse.Services.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private IUnitOfWork unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
