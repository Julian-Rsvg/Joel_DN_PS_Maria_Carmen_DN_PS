using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.Sales.Dto
{
    public class SellerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        

        /*public List<SaleProductDto> Sales { get; set; }

        public SellerDto()
        {
            Sales = new List<SaleProductDto>();
        }*/
    }
}
