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
    }
}
