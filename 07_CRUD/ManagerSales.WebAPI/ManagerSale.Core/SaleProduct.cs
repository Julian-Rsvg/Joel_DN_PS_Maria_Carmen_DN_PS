using ManagerSale.Core.CollectionFK;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.Core
{
    public class SaleProduct
    {
        [Key]
        public int Id { get; set; }

        //public Product  Product {get;set;}
        public int ProductId { get; set; }

        public Seller Seller { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
