using System;

namespace ManagerSale.WebAPI.Models
{
    public class SaleModel
    {
        
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
