using ManagerCollection.ApplicationServices.Collections.Categories;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppServices _categoryAppServices;

        Serilog.ILogger _logger;
        public CategoriesController(ICategoryAppServices categoryAppServices, Serilog.ILogger logger)
        {
            _categoryAppServices = categoryAppServices;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            List<CategoryDto> categories = await _categoryAppServices.GetCategoriesAsync();
            _logger.Information("Total categories: "+categories?.Count);

            return categories;
        }

        // GET api/
        [HttpGet("{id}")]
        public async Task<CategoryDto> Get(int id)
        {
            CategoryDto category = await _categoryAppServices.GetCategoryAsync(id);
            _logger.Information("Category id: "+id);
            return category;
        }

        // POST api/
        [HttpPost]
        public async Task<Int32> Post(CategoryModel entity)
        {
            Category category = new Category
            {
                Name = entity.Name
            };
            var Result = await _categoryAppServices.AddCategoryAsync(category);
            _logger.Information("insert values: " + category);
            return Result;
        }

        // PUT api/
        [HttpPut("{id}")]
        public async Task Put(int id, CategoryModel entity)
        {
            Category category = new Category
            {
                Id = id,
                Name = entity.Name
            };
            await _categoryAppServices.EditCategoryAsync(category);
            _logger.Information("Category value update: " + category);
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _categoryAppServices.DeleteCategoryAsync(id);
            _logger.Information("Category id delete: " + id);
        }
    }
}
