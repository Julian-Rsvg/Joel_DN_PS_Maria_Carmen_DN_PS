using ManagerCollection.ApplicationServices.Collections;
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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandAppServices _brandAppServices;

        Serilog.ILogger _logger;

        public BrandsController(IBrandAppServices brandAppServices, Serilog.ILogger logger)
        {
            _brandAppServices = brandAppServices;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/
        [HttpGet]
        public async Task<IEnumerable<BrandDto>> Get()
        {
            List<BrandDto> brands =await _brandAppServices.GetBrandsAsync();
            _logger.Information("Total list: "+ brands?.Count);            
            return brands;
        }

        // GET api/
        [HttpGet("{id}")]
        public async Task<BrandDto> Get(int id)
        {
            BrandDto brand = await _brandAppServices.GetBrandAsync(id);
            _logger.Information("Brand id: "+id);
            return brand;
        }

        // POST api/
        [HttpPost]
        public async Task<Int32> Post(BrandModel entity)
        {
            Brand brand = new Brand
            {
                Name = entity.Name
            };
            var Result = await _brandAppServices.AddBrandAsync(brand);
            _logger.Information("value insert: " + brand);
            return Result;
        }

        // PUT api/
        [HttpPut("{id}")]
        public async Task Put(int id, BrandModel entity)
        {
            Brand brand = new Brand
            {
                Id = id,
                Name = entity.Name
            };
            await _brandAppServices.EditBrandAsync(brand);
            _logger.Information("value update: " + brand);
            
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public async Task Delete (int id)
        {
            await _brandAppServices.DeleteBrandAsync(id);
            _logger.Information("id delete: " + id);
        }

    }
}
