using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices.Collections
{
    public interface IProductAppServices
    {
        void Insert(Product product);

        void Update(Product product);

        Product Get(int id);

        List<Product> GetAll();

        void Delete(int id);
    }
}
