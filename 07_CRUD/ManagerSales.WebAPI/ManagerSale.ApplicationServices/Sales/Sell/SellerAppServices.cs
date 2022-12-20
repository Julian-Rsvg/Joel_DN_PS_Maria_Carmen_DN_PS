using ManagerSale.Core;
using ManagerSale.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GymManager.DataAccess.Repositories;
using ManagerSale.Sales.Dto;
using Microsoft.EntityFrameworkCore;

namespace ManagerSale.ApplicationServices.Sales.Sell
{
    public class SellerAppServices : ISellerAppServices
    {
        private readonly IRepository<int, Seller> _repository;
        private readonly IMapper _mapper;

        public SellerAppServices(IRepository<int, Seller> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddSellerAsync(Seller seller)
        {
            if (string.IsNullOrWhiteSpace(seller.Name) || string.IsNullOrWhiteSpace(seller.LastName)
                || string.IsNullOrWhiteSpace(seller.Password) || string.IsNullOrWhiteSpace(seller.Email)
                )
            {
                throw new Exception("Dont't insert values null please!");
            }
            //var s = _mapper.Map<Core.Seller>(seller);
            await _repository.AddAsync(seller);
            return seller.Id;
        }

        public async Task DeleteSellerAsync(int sellerId)
        {
            await _repository.DeleteAsync(sellerId);
        }

        public async Task EditSellerAsync(Seller seller)
        {
            if (string.IsNullOrWhiteSpace(seller.Name) || string.IsNullOrWhiteSpace(seller.LastName)
                || string.IsNullOrWhiteSpace(seller.Password) || string.IsNullOrWhiteSpace(seller.Email)
                )
            {
                throw new Exception("Dont't insert values null please!");
            }
            //var s = _mapper.Map<Core.Seller>(seller);
            await _repository.UpdateAsync(seller);
        }

        public async Task<SellerDto> GetSellerAsync(int sellerId)
        {
            return _mapper.Map<SellerDto>(await _repository.GetAsync(sellerId));
        }

        public async Task<List<SellerDto>> GetSellersAsync()
        {
            var sellers = _mapper.Map<List<SellerDto>>(await _repository.GetAll().ToListAsync());
            return sellers;
        }
    }
}
