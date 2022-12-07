using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.Sales.Dto
{
    public class ProdDto
    {
        public int Id { get; set; }

        public List<SaleProductDto> Sales { get; set; }

        public ProdDto()
        {
            Sales = new List<SaleProductDto>();
        }
    }
}
