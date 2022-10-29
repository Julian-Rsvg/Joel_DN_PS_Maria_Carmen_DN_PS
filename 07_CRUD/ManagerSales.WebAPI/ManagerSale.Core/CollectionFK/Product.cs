using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.Core.CollectionFK
{
    public class Product
    {
        
        public int Id { get; set; }

        public List<SaleProduct> Sales { get; set; }

        public Product()
        {
            Sales = new List<SaleProduct>();
        }
    }
}
