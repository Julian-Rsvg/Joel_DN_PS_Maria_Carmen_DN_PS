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
        public async Task Post(SaleProductAddDto entity)
        {
            await _saleAppService.AddSaleProductAsync(entity);
            _logger.Information("Insert Sale: " + entity);
            
        }

        // PUT api/
        [HttpPut("{id}")]
        public async Task Put(int id, SaleProductAddDto entity)
        {            
            await _saleAppService.EditSaleProductAsync(id,entity);
            _logger.Information("Update product: " + entity);

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
