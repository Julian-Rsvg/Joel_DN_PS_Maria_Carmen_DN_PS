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

        public override async Task<Seller> GetAsync(int id)
        {
            var sale = await Context.Sellers.Include(x => x.Sales).FirstAsync(x => x.Id == id);
            return sale;
        }
    }
}
