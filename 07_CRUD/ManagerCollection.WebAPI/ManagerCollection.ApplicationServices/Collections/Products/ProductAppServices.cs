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

namespace ManagerCollection.ApplicationServices.Collections.Products
{
    public class ProductAppServices : IProductAppServices
    {
        private readonly IRepository<int, Product> _repository;
        private readonly IMapper _mapper;

        public ProductAppServices(IRepository<int, Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            //var p = _mapper.Map<Product>(product);
            await _repository.AddAsync(product);
            return product.Id;
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _repository.DeleteAsync(productId);
        }

        public async Task EditProductAsync(Product product)
        {
            //var p = _mapper.Map<Product>(product);
            await _repository.UpdateAsync(product);
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            var product = await _repository.GetAsync(productId);
            ProductDto dto = _mapper.Map<ProductDto>(product);
            return dto;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var u = await _repository.GetAll().ToListAsync();
            List<ProductDto> products = _mapper.Map<List<ProductDto>>(u);
            return products;
        }
    }
}
