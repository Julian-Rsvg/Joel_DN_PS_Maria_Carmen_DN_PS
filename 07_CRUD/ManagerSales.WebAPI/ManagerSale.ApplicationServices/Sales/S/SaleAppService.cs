﻿using ManagerSale.ApplicationServices.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ManagerSale.Sales.Dto;
using GymManager.DataAccess.Repositories;
using ManagerSale.Core.CollectionFK;
using ManagerSale.Core;
using Microsoft.EntityFrameworkCore;

namespace ManagerSale.ApplicationServices.Sales.S
{
    public class SaleAppService: ISaleAppService
    {
        private readonly IRepository<int, Core.SaleProduct> _repository;
        private readonly IProductCollectionAppService _prductAppService;
        IMapper _mapper;

        public SaleAppService(IRepository<int, Core.SaleProduct> repository, IProductCollectionAppService prductAppService, IMapper mapper)
        {
            _repository = repository;
            _prductAppService = prductAppService;
            _mapper = mapper;
        }

        public async Task<int> AddSaleProductAsync(SaleProduct entity)
        {
            var product = await _prductAppService.GetProduct(entity.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }
            Core.SaleProduct saleProduct = _mapper.Map<Core.SaleProduct>(entity);
            await _repository.AddAsync(saleProduct);
            return saleProduct.Id;
        }


        public async Task DeleteSaleProductAsync(int entityId)
        {
            await _repository.DeleteAsync(entityId);
        }

        public async Task EditSaleProductAsync(SaleProduct entity)
        {
            var product = await _prductAppService.GetProduct(entity.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }
            Core.SaleProduct saleProduct = _mapper.Map<Core.SaleProduct>(entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task<SaleProductDto> GetSaleProductAsync(int entityId)
        {
            var saleProduct = await _repository.GetAsync(entityId);
            SaleProductDto dto = _mapper.Map<SaleProductDto>(saleProduct);
            return dto;
        }

        public async Task<List<SaleProductDto>> GetSaleProductsAsync()
        {
            var u = await _repository.GetAll().ToListAsync();
            List<SaleProductDto> salePoducts = _mapper.Map<List<SaleProductDto>>(u);
            return salePoducts;
        }
    }
}