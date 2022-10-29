using ManagerSale.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Sales
{
    public interface ISellerAppServices
    {
        void Insert(Seller seller);

        void Update(Seller seller);

        Seller Get(int id);

        List<Seller> GetAll();

        void Delete(int id);
    }
}
