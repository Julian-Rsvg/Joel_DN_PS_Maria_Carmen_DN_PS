using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.Collection.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId {get;set;}
        

        public int CategoryId {get;set;}
        
    }
}
