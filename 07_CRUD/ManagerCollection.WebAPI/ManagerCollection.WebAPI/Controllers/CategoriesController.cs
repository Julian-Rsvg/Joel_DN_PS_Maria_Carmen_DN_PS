using ManagerCollection.ApplicationServices.Collections;
using ManagerCollection.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ManagerCollection.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppServices _categoryAppServices;

        private readonly ILogger<CategoriesController> _logger;
        public CategoriesController(ICategoryAppServices categoryAppServices, ILogger<CategoriesController> logger)
        {
            _categoryAppServices = categoryAppServices;
            _logger = logger;
        }

        // GET: api/
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = _categoryAppServices.GetAll();
            _logger.LogInformation("Total categories: "+categories?.Count);

            return categories;
        }

        // GET api/
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            _logger.LogInformation("Category id: "+id);
            return _categoryAppServices.Get(id);
        }

        // POST api/
        [HttpPost]
        public void Post([FromBody] Category value)
        {
            _logger.LogInformation("insert values: " + value);
            _categoryAppServices.Insert(value);
        }

        // PUT api/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category value)
        {
            value.Id = id;
            _logger.LogInformation("Category value update: " + value);
            _categoryAppServices.Update(value);
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("Category id delete: " + id);
            _categoryAppServices.Delete(id);
        }
    }
}
