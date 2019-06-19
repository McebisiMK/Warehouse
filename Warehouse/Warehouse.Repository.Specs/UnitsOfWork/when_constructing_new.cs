using Machine.Fakes;
using Machine.Specifications;
using Warehouse.Repositories.Products;
using Warehouse.Repositories.Suppliers;
using Warehouse.Repositories.UnitsOfWork;

namespace Warehouse.Repository.Specs.UnitsOfWork
{
    class when_constructing_new:WithSubject<UnitOfWork>
    {
        private static UnitOfWork unitOfWork;

        private Because of = () => { unitOfWork = new UnitOfWork(); };

        private It should_resolve_product_repositories = () =>
        {
            unitOfWork
                .ProductRepository
                .ShouldBeOfExactType<ProductRepository>();
        };

        private It should_resolve_supplier_repositories = () =>
        {
            unitOfWork
                .SupplierRepository
                .ShouldBeOfExactType<SupplierRepository>();
        };
    }
}
