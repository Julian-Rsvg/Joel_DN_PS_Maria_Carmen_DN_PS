using ManagerCollection.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.EntityFramework
{
    public class ManagerCollectionContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> ProductsType { get; set; }

        public ManagerCollectionContext(DbContextOptions<ManagerCollectionContext> options) : base(options)
        {

        }
    }
}
