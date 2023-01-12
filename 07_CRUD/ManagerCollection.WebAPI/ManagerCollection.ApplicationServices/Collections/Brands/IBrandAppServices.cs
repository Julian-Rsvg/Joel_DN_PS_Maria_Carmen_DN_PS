﻿using ManagerCollection.Collection.Dto;
using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices.Collections
{
    public interface IBrandAppServices
    {

        Task<List<BrandDto>> GetBrandsAsync();

        Task AddBrandAsync(BrandAddDto brand);

        Task DeleteBrandAsync(int brandId);
        Task<BrandDto> GetBrandAsync(int brandId);

        Task EditBrandAsync(int id, BrandAddDto brand);

    }
}
