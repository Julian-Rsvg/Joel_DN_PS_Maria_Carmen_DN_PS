using GymManager.DataAccess.Repositories;
using ManagerSale.Core;
using ManagerSale.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ManagerSale.EntityFramework.Repositories
{
    public class SaleProductRepository: Repository<int, SaleProduct>
    {
        public SaleProductRepository(ManagerSalesContext context): base(context)
        {

        }
        

        public override async Task<SaleProduct> AddAsync(SaleProduct saleProduct)
        {
            var seller = await Context.Sellers.FindAsync(saleProduct.Seller.Id);

            saleProduct.Seller = null;

            await Context.SaleProducts.AddAsync(saleProduct);
            seller.Sales.Add(saleProduct);

            await Context.SaveChangesAsync();

            return saleProduct;
        }

        public override async Task<SaleProduct> GetAsync(int id)
        {
            var product = await Context.SaleProducts.Include(x => x.Seller).FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
        public override async Task<SaleProduct> UpdateAsync(SaleProduct saleProduct)
        {
            var seller = await Context.Sellers.FindAsync(saleProduct.Seller.Id);

            var entity = await Context.SaleProducts.FindAsync(saleProduct.Id);

            entity.ProductId = saleProduct.ProductId;
            entity.Seller = seller;
            entity.Price = saleProduct.Price;
            entity.Quantity = saleProduct.Quantity;

            await Context.SaveChangesAsync();

            return entity;
        }

        public override IQueryable<SaleProduct> GetAll()
        {
            var products = from p in Context.SaleProducts.Include(x => x.Seller) select p;
            return products;
        }

    }
}
