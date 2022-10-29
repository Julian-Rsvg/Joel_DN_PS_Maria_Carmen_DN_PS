﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.Core
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        //public int BrandId { get; set; }
        public Brand Brand { get; set; }

        //[Required]
        //public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
        
}