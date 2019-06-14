﻿using System.Web.Http;
using Warehouse.IServices.Products;

namespace Warehouse.Web.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll()
        {
            var products = productService.GetAll();

            return Ok(products);
        }
    }
}
