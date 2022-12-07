using ManagerSale.Core.CollectionFK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Collection
{
    public interface IProductCollectionAppService
    {
        Task<Product> GetProduct(int id);
    }
}
