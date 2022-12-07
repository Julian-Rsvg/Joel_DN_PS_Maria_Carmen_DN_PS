using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ManagerCollection.Core.Brand, Collection.Dto.BrandDto>();
            CreateMap<ManagerCollection.Collection.Dto.BrandDto, ManagerCollection.Core.Brand>();


            CreateMap<ManagerCollection.Core.Category, ManagerCollection.Collection.Dto.CategoryDto>();
            CreateMap<ManagerCollection.Collection.Dto.CategoryDto, ManagerCollection.Core.Category>();


            CreateMap<ManagerCollection.Core.Product, ManagerCollection.Collection.Dto.ProductDto>();
            //CreateMap<ManagerCollection.Collection.Dto.ProductDto, ManagerCollection.Core.Product>();
        }
    }
}
