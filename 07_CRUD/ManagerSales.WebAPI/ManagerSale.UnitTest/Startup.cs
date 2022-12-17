using GymManager.DataAccess.Repositories;
using ManagerSale.ApplicationServices.Collection;
using ManagerSale.ApplicationServices.Sales.S;
using ManagerSale.ApplicationServices.Sales.Sell;
using ManagerSale.EntityFramework;
using ManagerSale.EntityFramework.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.UnitTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<ManagerSalesContext>(options =>
                options.UseInMemoryDatabase("SalesTest"));


            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            

            services.AddTransient<ISellerAppServices, SellerAppServices>();
            services.AddTransient<IRepository<int, ManagerSale.Core.Seller>, Repository<int, ManagerSale.Core.Seller>>();
            //services.AddTransient<IRepository<int, ManagerSale.Core.Seller>, SellerRepository>();
            
            services.AddTransient<IProductCollectionAppService, ProductCollectionTestAppService>();

            services.AddTransient<ISaleAppService, SaleAppService>();
            services.AddTransient<IRepository<int, ManagerSale.Core.SaleProduct>, SaleProductRepository>();
            //services.AddTransient<IRepository<int, ManagerSale.Core.SaleProduct>, Repository<int, ManagerSale.Core.SaleProduct>>();


            services.AddAutoMapper(typeof(ManagerSale.ApplicationServices.MapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
