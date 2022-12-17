using ManagerSale.Core;
using ManagerSale.Core.CollectionFK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.Sales.Dto
{
    public class SaleProductDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
                
        public SellerDto Seller { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public SaleProductDto()
        {
            Seller = new SellerDto();
        }
    }
}
