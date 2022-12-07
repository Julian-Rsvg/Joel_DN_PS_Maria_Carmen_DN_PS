using ManagerSale.Core;
using ManagerSale.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Sales.Sell
{
    public interface ISellerAppServices
    {
        Task<List<SellerDto>> GetSellersAsync();

        Task<int> AddSellerAsync(Seller seller);

        Task DeleteSellerAsync(int sellerId);
        Task<SellerDto> GetSellerAsync(int sellerd);

        Task EditSellerAsync(Seller seller);
    }
}
