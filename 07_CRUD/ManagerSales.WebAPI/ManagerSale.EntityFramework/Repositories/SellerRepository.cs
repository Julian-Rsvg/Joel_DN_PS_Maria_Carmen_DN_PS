using GymManager.DataAccess.Repositories;
using ManagerSale.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ManagerSale.EntityFramework.Repositories
{
    public class SellerRepository: Repository<int, Seller>
    {
        public SellerRepository(ManagerSalesContext context): base(context)
        {

        }

        public override async Task<Seller> UpdateAsync(Seller seller)
        {
            var entity = await Context.Sellers.FindAsync(seller.Id);

            entity.Name = seller.Name;
            entity.LastName = seller.LastName;
            entity.Email = seller.Email;
            entity.Password = seller.Password;

            await Context.SaveChangesAsync();

            return entity;
        }
    }
}
