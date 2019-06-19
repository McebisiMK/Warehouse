using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse.IServices.Suppliers;

namespace Warehouse.Web.Controllers
{
    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiController
    {
        private ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
    }
}
