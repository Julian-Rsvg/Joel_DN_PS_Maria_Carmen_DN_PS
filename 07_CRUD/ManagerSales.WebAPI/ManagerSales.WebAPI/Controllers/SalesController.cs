using ManagerSale.ApplicationServices.Collection;
using ManagerSale.ApplicationServices.Sales.S;
using ManagerSale.Core;
using ManagerSale.Core.CollectionFK;
using ManagerSale.Sales.Dto;
using ManagerSale.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManagerSale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleAppService _saleAppService;
        private readonly ProductCollectionAppService _prodAppS;
        Serilog.ILogger _logger;
        public SalesController(ISaleAppService saleAppService, Serilog.ILogger logger, ProductCollectionAppService prodAppS)
        {
            _saleAppService = saleAppService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _prodAppS = prodAppS;
        }

        [HttpPost]
        public async Task<Int32> Post(SaleProductDto entity)
        {
            /*SaleProduct sale = new SaleProduct { 
                ProductId = entity.ProductId,
                Seller= new Seller
                {
                    Id =entity.SellerId
                },
                Quantity = entity.Quantity,
                Price = entity.Price,
                CreatedOn = entity.CreatedOn
            };*/
            var Result = await _saleAppService.AddSaleProductAsync(entity);
            _logger.Information("Insert Sale: " + entity);
            return Result;
        }

        /*[HttpGet("{id}")]
         public async Task<Product> Get(int id)
        {
            Product prod = await _prodAppS.GetProduct(id);
            _logger.Information("product id: " + id);
            return prod;
        }*/

        // GET api/
        /*[HttpGet("{id}")]
        public async Task<ProdDto> Get(int id)
        {
            ProdDto prod = await _saleAppService.GetProductAsync(id);            
            _logger.Information("product id: " + id);
            return prod;
        }*/
    }
}
