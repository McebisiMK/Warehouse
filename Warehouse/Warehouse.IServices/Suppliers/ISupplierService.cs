using System.Collections.Generic;
using Warehouse.Entities;

namespace Warehouse.IServices.Suppliers
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        int Add(Supplier supplier);
    }
}
