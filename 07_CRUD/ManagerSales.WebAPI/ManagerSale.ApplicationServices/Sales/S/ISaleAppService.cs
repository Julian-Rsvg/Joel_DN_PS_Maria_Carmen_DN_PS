using ManagerSale.Core;
using ManagerSale.Core.CollectionFK;
using ManagerSale.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Sales.S
{
    public interface ISaleAppService
    {
        //Task<List<SaleProductDto>> GetSaleProductsAsync();

        Task<int> AddSaleProductAsync(SaleProductDto entity);

        Task<ProdDto> GetProductAsync(int entityId);

        /*Task DeleteSaleProductAsync(int entityId);
        Task<SaleProductDto> GetSaleProductAsync(int entityId);

        Task EditSaleProductAsync(SaleProductDto entity);*/
    }
}
