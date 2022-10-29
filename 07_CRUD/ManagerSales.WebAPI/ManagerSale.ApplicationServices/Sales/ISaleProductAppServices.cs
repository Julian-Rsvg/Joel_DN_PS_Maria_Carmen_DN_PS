using ManagerSale.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Sales
{
    public interface ISaleProductAppServices
    {
        void Insert(SaleProduct saleProduct);

        void Update(SaleProduct saleProduct);

        SaleProduct Get(int id);

        List<SaleProduct> GetAll();

        void Delete(int id);
    }
}
