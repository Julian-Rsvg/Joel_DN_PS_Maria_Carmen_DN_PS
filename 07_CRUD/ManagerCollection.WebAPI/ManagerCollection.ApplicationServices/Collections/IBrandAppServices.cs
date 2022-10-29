using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices.Collections
{
    public interface IBrandAppServices
    {
        

        void Insert(Brand brand);

        void Update(Brand brand);

        Brand Get(int id);

        List<Brand> GetAll();

        void Delete(int id);

    }
}
