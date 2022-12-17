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

        public BrandAppServices(IRepository<int, Core.Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddBrandAsync(Brand brand)
        {
            //var b = _mapper.Map<Core.Brand>(brand);
            await _repository.AddAsync(brand);
            return brand.Id;
        }

        public async Task DeleteBrandAsync(int brandId)
        {
            await _repository.DeleteAsync(brandId);
        }

        public async Task EditBrandAsync(Brand brand)
        {
            //var b = _mapper.Map<Core.Brand>(brand);
            await _repository.UpdateAsync(brand);
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
