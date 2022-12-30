using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.Sales.Dto
{
    public class SaleProductAddDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
