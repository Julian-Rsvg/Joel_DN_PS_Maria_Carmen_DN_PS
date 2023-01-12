using ManagerSale.ApplicationServices.Sales.Sell;
using ManagerSale.Core;
using ManagerSale.Sales.Dto;
using ManagerSale.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ManagerSale.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SellersController : ControllerBase
    {
        private readonly ISellerAppServices _sellerAppServices;

        Serilog.ILogger _logger;

        public SellersController(ISellerAppServices sellerAppServices, Serilog.ILogger logger)
        {
            _sellerAppServices = sellerAppServices;
            _logger = logger;
        }

        // GET: api/
        [HttpGet]
        public async Task<IEnumerable<SellerDto>> Get()
        {
            List<SellerDto> sellers = await _sellerAppServices.GetSellersAsync();
            _logger.Information("Total sellers: " + sellers?.Count);
            return sellers;
        }

        // GET api/
        [HttpGet("{id}")]
        public async Task<SellerDto> Get(int id)
        {
            SellerDto seller = await _sellerAppServices.GetSellerAsync(id);
            _logger.Information("Seller id: " + id);
            return seller;
        }

        // POST api/
        [HttpPost]
        public async Task Post(SellerAddDto entity)
        {           
            await _sellerAppServices.AddSellerAsync(entity);
            _logger.Information("Insert seller: " + entity);
        }

        // PUT api/
        [HttpPut("{id}")]
        public async Task Put(int id, SellerAddDto entity)
        {
            await _sellerAppServices.EditSellerAsync(id, entity);
            _logger.Information("Seller upadate: " +entity);
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _sellerAppServices.DeleteSellerAsync(id);
            _logger.Information("seller Remove: " + id);
        }

    }
}
