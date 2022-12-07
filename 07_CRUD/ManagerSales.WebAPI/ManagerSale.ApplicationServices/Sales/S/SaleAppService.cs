using ManagerSale.ApplicationServices.Collection;
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

        public async Task<int> AddSaleProductAsync(SaleProductDto entity)
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

        public async Task<ProdDto> GetProductAsync(int entityId)
        {
            return _mapper.Map<ProdDto>(await _prductAppService.GetProduct(entityId));
        }

        /*public Task DeleteSaleProductAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task EditSaleProductAsync(SaleProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaleProductDto> GetSaleProductAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SaleProductDto>> GetSaleProductsAsync()
        {
            throw new NotImplementedException();
        }*/
    }
}
