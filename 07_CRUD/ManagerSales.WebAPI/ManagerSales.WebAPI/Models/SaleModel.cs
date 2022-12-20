using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerSale.WebAPI.Models
{
    public class SaleModel
    {

        //public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        //public DateTime CreatedOn { get; set; }
    }
}
