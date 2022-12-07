using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ManagerSale.Core.SaleProduct, ManagerSale.Sales.Dto.SaleProductDto>();
            CreateMap<ManagerSale.Sales.Dto.SaleProductDto, ManagerSale.Core.SaleProduct>();


            CreateMap<ManagerSale.Core.Seller, ManagerSale.Sales.Dto.SellerDto>();
            //CreateMap<ManagerSale.Sales.Dto.SellerDto, ManagerSale.Core.Seller>();

            CreateMap<ManagerSale.Core.CollectionFK.Product, ManagerSale.Sales.Dto.ProdDto>();
        }
    }
}
