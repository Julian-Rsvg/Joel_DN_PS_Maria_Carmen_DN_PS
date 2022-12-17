using GymManager.DataAccess.Repositories;
using ManagerCollection.ApplicationServices.Collections;
using ManagerCollection.ApplicationServices.Collections.Categories;
using ManagerCollection.ApplicationServices.Collections.Products;
using ManagerCollection.EntityFramework;
using ManagerCollection.EntityFramwork.Repositories;
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

namespace ManagerCollection.UnitTest
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

            services.AddDbContext<ManagerCollectionContext>(options =>
                options.UseInMemoryDatabase("CollectionTest"));

            services.AddControllers();


            services.AddTransient<IBrandAppServices, BrandAppServices>();
            services.AddTransient<IRepository<int, Core.Brand>, Repository<int, Core.Brand>>();
            //services.AddTransient<IRepository<int, Core.Brand>, BrandRepository>();

            services.AddTransient<ICategoryAppServices, CategoryAppServices>();
            services.AddTransient<IRepository<int, Core.Category>, Repository<int, Core.Category>>();
            //services.AddTransient<IRepository<int, Core.Category>, CategoryRepository>();

            services.AddTransient<IProductAppServices, ProductAppServices>();
            services.AddTransient<IRepository<int, Core.Product>, ProductRepository>();


            services.AddAutoMapper(typeof(ManagerCollection.ApplicationServices.MapperProfile));

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
