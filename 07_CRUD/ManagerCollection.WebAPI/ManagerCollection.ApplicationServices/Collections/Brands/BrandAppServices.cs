using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagerCollection.EntityFramework;
using GymManager.DataAccess.Repositories;
using ManagerCollection.Collection.Dto;
using AutoMapper;

namespace ManagerCollection.ApplicationServices.Collections
{
    
    public class BrandAppServices : IBrandAppServices
    {
        private readonly IRepository<int,Core.Brand> _repository;
        private readonly IMapper _mapper;
        private int id;

        public BrandAppServices(IRepository<int, Core.Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddBrandAsync(BrandAddDto brand)
        {
            if (string.IsNullOrWhiteSpace(brand.Name))
            {
                throw new Exception("value is null!, Insert Name!");
            }
            var b = _mapper.Map<Core.Brand>(brand);
            await _repository.AddAsync(b);
            //return brand.Id;
        }

        public async Task DeleteBrandAsync(int brandId)
        {
            await _repository.DeleteAsync(brandId);
        }

        public async Task EditBrandAsync(int id, BrandAddDto brand)
        {
            if (string.IsNullOrWhiteSpace(brand.Name))
            {
                throw new Exception("value is null!, Insert Name!");
            }
            var b = _mapper.Map<Core.Brand>(brand);
            b.Id = id;
            await _repository.UpdateAsync(b);
        }

        public async Task<BrandDto> GetBrandAsync(int brandId)
        {
            return _mapper.Map<BrandDto>(await _repository.GetAsync(brandId));
        }

        public async Task<List<BrandDto>> GetBrandsAsync()
        {
            var products = _mapper.Map<List<BrandDto>>(await _repository.GetAll().ToListAsync());
            return products;
        }
    }
}
