using ManagerSale.ApplicationServices.Collection;
using ManagerSale.ApplicationServices.Sales.S;
using ManagerSale.Core;
using ManagerSale.Core.CollectionFK;
using ManagerSale.Sales.Dto;
using ManagerSale.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagerSale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleAppService _saleAppService;
        Serilog.ILogger _logger;
        public SalesController(ISaleAppService saleAppService, Serilog.ILogger logger)
        {
            _saleAppService = saleAppService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/
        [HttpGet]
        public async Task<List<SaleProductDto>> Get()
        {
            List<SaleProductDto> products = await _saleAppService.GetSaleProductsAsync();
            _logger.Information("Products total: " + products?.Count);
            return products;
        }

        // GET api/
        [HttpGet("{id}")]
        public async Task<SaleProductDto> Get(int id)
        {
            SaleProductDto product = await _saleAppService.GetSaleProductAsync(id);
            _logger.Information("product id: " + id);
            return product;
        }

        [HttpPost]
        public async Task<Int32> Post(SaleModel entity)
        {
            SaleProduct sale = new SaleProduct { 
                ProductId = entity.ProductId,
                Seller= new Seller
                {
                    Id =entity.SellerId
                },
                Quantity = entity.Quantity,
                Price = entity.Price
            };
            var Result = await _saleAppService.AddSaleProductAsync(sale);
            _logger.Information("Insert Sale: " + sale);
            return Result;
        }

        // PUT api/
        [HttpPut("{id}")]
        public async Task Put(int id, SaleModel entity)
        {
            SaleProduct sale = new SaleProduct
            {
                Id = id,
                ProductId = entity.ProductId,
                Seller = new Seller
                {
                    Id = entity.SellerId
                },
                Quantity = entity.Quantity,
                Price = entity.Price
            };
            await _saleAppService.EditSaleProductAsync(sale);
            _logger.Information("Update product: " + sale);

        }

        // DELETE api/
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _saleAppService.DeleteSaleProductAsync(id);
            _logger.Information("product delete: " + id);
        }

    }
}
