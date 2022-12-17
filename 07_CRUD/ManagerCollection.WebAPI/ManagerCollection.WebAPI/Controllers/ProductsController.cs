using ManagerCollection.ApplicationServices.Collections.Products;
using ManagerCollection.Collection.Dto;
using ManagerCollection.Core;
using ManagerCollection.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagerCollection.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppServices _productAppServices;

        Serilog.ILogger _logger;

        public ProductsController(IProductAppServices productAppServices, Serilog.ILogger logger)
        {
            _productAppServices = productAppServices;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/
        [HttpGet]
        public async Task<List<ProductDto>> Get()
        {
            List<ProductDto> products = await _productAppServices.GetProductsAsync();
            _logger.Information("Products total: " + products?.Count);
            return products;
        }

        // GET api/
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            ProductDto product = await _productAppServices.GetProductAsync(id);
            _logger.Information("product id: " + id);
            return product;
        }

        // POST api/
        [HttpPost]
        public async Task<Int32> Post(ProductModel entity)
        {
            Product product = new Product { 
                Name= entity.Name,
                Brand = new Brand
                {
                    Id=entity.BrandId
                },
                Category = new Category
                {
                    Id= entity.CategoryId
                }
            };
            var Result = await _productAppServices.AddProductAsync(product);
            _logger.Information("Insert product: " + product);
            return Result;            
        }

        // PUT api/
        [HttpPut("{id}")]
        public async Task Put(int id, ProductModel entity)
        {
            Product product = new Product
            {
                Id=id,
                Name = entity.Name,
                Brand = new Brand
                {
                    Id = entity.BrandId
                },
                Category = new Category
                {
                    Id = entity.CategoryId
                }
            };
            await _productAppServices.EditProductAsync(product);
            _logger.Information("Update product: " + product);
            
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _productAppServices.DeleteProductAsync(id);
            _logger.Information("product delete: " + id);
        }

    }
}
