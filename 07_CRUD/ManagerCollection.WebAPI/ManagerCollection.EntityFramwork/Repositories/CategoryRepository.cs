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
    public class CategoryRepository: Repository<int, Category>
    {
        public CategoryRepository(ManagerCollectionContext context) : base(context)
        {

        }
        public override async Task<Category> GetAsync(int id)
        {
            var category = await Context.Categories.Include(x => x.Products).FirstAsync(x => x.Id == id);
            return category;
        }
    }
}
