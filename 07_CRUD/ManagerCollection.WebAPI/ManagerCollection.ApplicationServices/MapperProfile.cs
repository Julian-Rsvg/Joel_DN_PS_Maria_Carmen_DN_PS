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
            CreateMap<ManagerCollection.Collection.Dto.BrandAddDto, ManagerCollection.Core.Brand>();


            CreateMap<ManagerCollection.Core.Category, ManagerCollection.Collection.Dto.CategoryDto>();
            CreateMap<ManagerCollection.Collection.Dto.CategoryAddDto, ManagerCollection.Core.Category>();


            CreateMap<ManagerCollection.Core.Product, ManagerCollection.Collection.Dto.ProductDto>();
            CreateMap<ManagerCollection.Collection.Dto.ProductAddDto, ManagerCollection.Core.Product>()
                .ForPath(dest => dest.Brand.Id, opt => opt.MapFrom(src => src.BrandId))
                .ForPath(dest => dest.Category.Id, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}
