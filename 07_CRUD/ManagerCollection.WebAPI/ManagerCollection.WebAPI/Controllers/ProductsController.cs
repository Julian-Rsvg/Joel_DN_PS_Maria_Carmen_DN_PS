using ManagerCollection.ApplicationServices.Collections;
using ManagerCollection.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ManagerCollection.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppServices _productAppServices;

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductAppServices productAppServices, ILogger<ProductsController> logger)
        {
            _productAppServices = productAppServices;
            _logger = logger;
        }

        // GET: api/
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _productAppServices.GetAll();
            _logger.LogInformation("Products total: " + products?.Count);
            return products;
        }

        // GET api/
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            _logger.LogInformation("product id: " + id);
            return _productAppServices.Get(id);
        }

        // POST api/
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _logger.LogInformation("Insert product: " + value);
            _productAppServices.Insert(value);
        }

        // PUT api/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            value.Id = id;
            _logger.LogInformation("Update product: " +value);
            _productAppServices.Update(value);
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("product delete: " + id);
            _productAppServices.Delete(id);
        }

    }
}
