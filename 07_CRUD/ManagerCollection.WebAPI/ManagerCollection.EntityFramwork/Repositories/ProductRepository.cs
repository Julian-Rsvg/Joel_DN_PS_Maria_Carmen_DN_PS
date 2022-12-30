using GymManager.DataAccess.Repositories;
using ManagerCollection.Collection.Dto;
using ManagerCollection.Core;
using ManagerCollection.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.EntityFramwork.Repositories
{
    public class ProductRepository: Repository<int, Core.Product>
    {
        public ProductRepository(ManagerCollectionContext context): base(context)
        {

        }

        public override async Task<Product> AddAsync(Product product)
        {
            var brand = await Context.Brands.FindAsync(product.Brand.Id);
            var category = await Context.Categories.FindAsync(product.Category.Id);

            product.Brand = null;
            product.Category = null;

            await Context.ProductsType.AddAsync(product);
            brand.Products.Add(product);
            category.Products.Add(product);

            await Context.SaveChangesAsync();

            return product;
        }

        

        public override async Task<Product> GetAsync(int id)
        {
            var product = await Context.ProductsType.Include(x => x.Brand).Include(x=>x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public override async Task<Product> UpdateAsync(Product product)
        {
            var brand = await  Context.Brands.FindAsync(product.Brand.Id);
            var category =await Context.Categories.FindAsync(product.Category.Id);


            var entity = await Context.ProductsType.FindAsync(product.Id);            

            entity.Name = product.Name;
            entity.Category = category;
            entity.Brand = brand;

            await Context.SaveChangesAsync();

            return entity;
        }

        public override IQueryable<Product> GetAll()
        {
            var products = from p in Context.ProductsType.Include(x => x.Brand).Include(x => x.Category) select p;
            return products;
        }

    }
}
