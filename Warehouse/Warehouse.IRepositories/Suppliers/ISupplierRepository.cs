using System.Collections.Generic;
using Warehouse.Entities;

namespace Warehouse.IRepositories.Suppliers
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();
        int Add(Supplier supplier);
    }
}
