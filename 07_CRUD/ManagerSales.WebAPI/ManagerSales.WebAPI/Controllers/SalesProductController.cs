using ManagerSale.ApplicationServices.Sales;
using ManagerSale.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ManagerSale.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SalesProductController : ControllerBase
    {
        private readonly ISaleProductAppServices _saleproductAppService;

        private readonly ILogger<SalesProductController> _logger;

        public SalesProductController(ISaleProductAppServices saleproductAppService, ILogger<SalesProductController> logger)
        {
            _saleproductAppService = saleproductAppService;
            _logger = logger;
        }

        // GET: api/
        [HttpGet]
        public IEnumerable<SaleProduct> Get()
        {
            var saleProducts = _saleproductAppService.GetAll();

            _logger.LogInformation("Total Sales: " + saleProducts?.Count);
            return saleProducts;
        }

        // GET api/
        [HttpGet("{id}")]
        public SaleProduct Get(int id)
        {
            _logger.LogInformation("Sale product id: " + id);
            return _saleproductAppService.Get(id);
        }

        // POST api/
        [HttpPost]
        public void Post([FromBody] SaleProduct value)
        {
            _logger.LogInformation("Insert Saleproduct: " + value);
            _saleproductAppService.Insert(value);
        }

        // PUT api/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SaleProduct value)
        {
            value.Id = id;
            _logger.LogInformation("Update saleproduct: " + value);
            _saleproductAppService.Update(value);
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("Remove id: " + id);
            _saleproductAppService.Delete(id);
        }
    }
}
