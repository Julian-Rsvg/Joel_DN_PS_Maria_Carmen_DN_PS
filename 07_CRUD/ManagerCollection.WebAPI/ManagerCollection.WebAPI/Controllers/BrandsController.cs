using ManagerCollection.ApplicationServices.Collections;
using ManagerCollection.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagerCollection.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandAppServices _brandAppServices;

        private readonly ILogger<BrandsController> _logger;
        public BrandsController(IBrandAppServices brandAppServices, ILogger<BrandsController> logger)
        {
            _brandAppServices = brandAppServices;
            _logger = logger;
        }

        // GET: api/
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            var brands = _brandAppServices.GetAll();
            _logger.LogInformation("Total list: "+ brands?.Count);
            
            return brands;
        }

        // GET api/
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            _logger.LogInformation("Query id: "+id);
            return _brandAppServices.Get(id);
        }

        // POST api/
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            _logger.LogInformation("value insert: " + value);
            _brandAppServices.Insert(value);
        }

        // PUT api/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Brand value)
        {
            value.Id = id;
            _logger.LogInformation("value update: " + value);
            _brandAppServices.Update(value);
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("id delete: " + id);
            _brandAppServices.Delete(id);
        }

    }
}
