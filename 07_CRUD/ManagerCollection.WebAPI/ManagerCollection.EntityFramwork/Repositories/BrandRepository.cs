using GymManager.DataAccess.Repositories;
using ManagerCollection.Core;
using ManagerCollection.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ManagerCollection.EntityFramwork.Repositories
{
    public class BrandRepository: Repository<int, Brand>
    {
        public BrandRepository(ManagerCollectionContext context) : base(context)
        {

        }

        public override async Task<Brand> GetAsync(int id)
        {
            var brand = await Context.Brands.Include(x => x.Products).FirstAsync(x => x.Id == id);
            return brand;
        }
    }
}
