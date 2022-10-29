using ManagerSale.ApplicationServices.Sales;
using ManagerSale.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ManagerSale.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SellersController : ControllerBase
    {
        private readonly ISellerAppServices _sellerAppServices;

        private readonly ILogger<SellersController> _logger;

        public SellersController(ISellerAppServices sellerAppServices, ILogger<SellersController> logger)
        {
            _sellerAppServices = sellerAppServices;
            _logger = logger;
        }

        // GET: api/
        [HttpGet]
        public IEnumerable<Seller> Get()
        {
            var sellers = _sellerAppServices.GetAll();
            _logger.LogInformation("Total sellers: " + sellers?.Count);
            return sellers;
        }

        // GET api/
        [HttpGet("{id}")]
        public Seller Get(int id)
        {
            _logger.LogInformation("Seller id: " + id);
            return _sellerAppServices.Get(id);
        }

        // POST api/
        [HttpPost]
        public void Post([FromBody] Seller value)
        {
            _logger.LogInformation("Insert seller: " + value);
            _sellerAppServices.Insert(value);
        }

        // PUT api/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Seller value)
        {
            value.Id = id;
            _logger.LogInformation("Seller upadate: " +value);
            _sellerAppServices.Update(value);
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("seller Remove: " + id);
            _sellerAppServices.Delete(id);
        }

    }
}
