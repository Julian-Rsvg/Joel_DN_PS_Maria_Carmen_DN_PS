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
        private readonly IRepository<int, Brand> _repositoryB;
        private readonly IRepository<int, Category> _repositoryC;
        private readonly IMapper _mapper;

        public ProductAppServices(IRepository<int, Product> repository, IMapper mapper, 
            IRepository<int, Brand> repositoryB, IRepository<int, Category> repositoryC)
        {
            _repository = repository;
            _repositoryB = repositoryB;
            _repositoryC = repositoryC;
            _mapper = mapper;
        }

        public async Task AddProductAsync(ProductAddDto product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new Exception("value is null!, Insert Name!");
            }
            var brand = await _repositoryB.GetAsync(product.BrandId);
            var category = await _repositoryC.GetAsync(product.CategoryId);

            if(brand == null)
            {
                throw new Exception("Brand don't found!");
            }
            if (category == null)
            {
                throw new Exception("category don't found!");
            }


            var p = _mapper.Map<Core.Product>(product);
            await _repository.AddAsync(p);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _repository.DeleteAsync(productId);
        }

        public async Task EditProductAsync(int id, ProductAddDto product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new Exception("value is null!, Insert Name!");
            }
            var brand = await _repositoryB.GetAsync(product.BrandId);
            var category = await _repositoryC.GetAsync(product.CategoryId);

            if (brand == null)
            {
                throw new Exception("Brand don't found!");
            }
            if (category == null)
            {
                throw new Exception("category don't found!");
            }
            var p = _mapper.Map<Core.Product>(product);
            p.Id = id;
            await _repository.UpdateAsync(p);
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
