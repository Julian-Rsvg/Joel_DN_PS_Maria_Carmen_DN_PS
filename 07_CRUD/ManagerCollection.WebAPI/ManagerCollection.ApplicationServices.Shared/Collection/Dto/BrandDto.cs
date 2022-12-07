﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.Collection.Dto
{
    public class BrandDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<ProductDto> Products { get; set; }

        public BrandDto()
        {
            Products = new List<ProductDto>();
        }
    }
}
