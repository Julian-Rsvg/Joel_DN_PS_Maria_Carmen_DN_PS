using GymManager.DataAccess.Repositories;
using ManagerCollection.Core;
using ManagerCollection.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ManagerCollection.Collection.Dto;

namespace ManagerCollection.ApplicationServices.Collections.Categories
{
    public class CategoryAppServices : ICategoryAppServices
    {
        private readonly IRepository<int, Core.Category> _repository;
        private readonly IMapper _mapper;

        public CategoryAppServices(IRepository<int, Core.Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryDto category)
        {
            var c = _mapper.Map<Core.Category>(category);
            await _repository.AddAsync(c);
            return category.Id;
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _repository.DeleteAsync(categoryId);
        }

        public async Task EditCategoryAsync(CategoryDto category)
        {
            var c = _mapper.Map<Core.Category>(category);
            await _repository.UpdateAsync(c);
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            /*var u = await _repository.GetAll().ToListAsync();
            List<CategoryDto> category = _mapper.Map<List<CategoryDto>>(u);
            return category;*/
            var categories = _mapper.Map<List<CategoryDto>>(await _repository.GetAll().ToListAsync());
            return categories;
        }

        public async Task<CategoryDto> GetCategoryAsync(int categoryId)
        {
            /*var category = await _repository.GetAsync(categoryId);
            CategoryDto dto = _mapper.Map<CategoryDto>(category);
            return dto;*/
            return _mapper.Map<CategoryDto>(await _repository.GetAsync(categoryId));
        }
    }
}
