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
        public override async Task<Category> UpdateAsync(Category category)
        {
            var entity = await Context.Categories.FindAsync(category.Id);

            entity.Name = category.Name;

            await Context.SaveChangesAsync();

            return entity;
        }
    }
}
