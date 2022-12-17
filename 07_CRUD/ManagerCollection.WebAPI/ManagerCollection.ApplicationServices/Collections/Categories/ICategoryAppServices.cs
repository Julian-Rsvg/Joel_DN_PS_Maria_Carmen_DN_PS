using ManagerCollection.Collection.Dto;
using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices.Collections.Categories
{
    public interface ICategoryAppServices
    {
        Task<List<CategoryDto>> GetCategoriesAsync();

        Task<int> AddCategoryAsync(Category category);

        Task DeleteCategoryAsync(int categoryId);
        Task<CategoryDto> GetCategoryAsync(int categoryId);

        Task EditCategoryAsync(Category category);
    }
}
