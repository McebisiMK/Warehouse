using System;
using System.Collections.Generic;
using Warehouse.Entities;
using Warehouse.IRepositories.Suppliers;
using Warehouse.IServices.Suppliers;

namespace Warehouse.Services.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public int Add(Supplier supplier)
        {
            supplier = new Supplier()
            {
                Id = 2,
                Name = "Mce",
                Quantity = 5,
                ExpiryDate = DateTime.Now
            };

            var results = supplierRepository.Add(supplier);

            return results;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return supplierRepository.GetAll();
        }
    }
}
