using ManagerSale.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Collection
{
    public class ProductCollectionTestAppService : IProductCollectionAppService
    {
        public async Task<ProdDto> GetProduct(int id)
        {
            if (id > 0) return await Task.FromResult(new ProdDto());
            else return await Task.FromResult<ProdDto>(null);
        }
    }
}
