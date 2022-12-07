using ManagerCollection.Collection.Dto;
using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices.Collections.Products
{
    public interface IProductAppServices
    {
        Task<List<ProductDto>> GetProductsAsync();

        Task<int> AddProductAsync(Product product);

        Task DeleteProductAsync(int productId);
        Task<ProductDto> GetProductAsync(int productId);

        Task EditProductAsync(Product product);
    }
}
