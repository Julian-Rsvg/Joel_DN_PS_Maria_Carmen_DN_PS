using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices.Collections
{
    public interface ICategoryAppServices
    {
        void Insert(Category category);

        void Update(Category category);

        Category Get(int id);

        List<Category> GetAll();

        void Delete(int id);
    }
}
