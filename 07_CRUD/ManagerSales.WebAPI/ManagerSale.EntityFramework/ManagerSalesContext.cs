using ManagerSale.Core;
using ManagerSale.Core.CollectionFK;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.EntityFramework
{
    public class ManagerSalesContext: DbContext
    {
        public virtual DbSet<Seller> Sellers{ get; set; }

        public virtual DbSet<SaleProduct> SaleProducts { get; set; }

        public virtual DbSet<Product> ProductsType { get; set; }

        public ManagerSalesContext(DbContextOptions<ManagerSalesContext> options) : base(options)
        {

        }
    }
}
