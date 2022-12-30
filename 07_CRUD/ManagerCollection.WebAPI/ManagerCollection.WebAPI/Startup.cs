using GymManager.DataAccess.Repositories;
using ManagerCollection.ApplicationServices.Collections;
using ManagerCollection.ApplicationServices.Collections.Categories;
using ManagerCollection.ApplicationServices.Collections.Products;
using ManagerCollection.Core;
using ManagerCollection.EntityFramework;
using ManagerCollection.EntityFramwork.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ManagerCollection.WebAPI
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

            services.AddDbContext<ManagerCollectionContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            /*services.AddDbContext<ManagerSalesContext>(options =>
                options.UseInMemoryDatabase("CollectionDB"));*/

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManagerCollection.WebAPI", Version = "v1" });
            });


            services.AddTransient<IBrandAppServices, BrandAppServices>();
            services.AddTransient<IRepository<int, Core.Brand>, Repository<int, Core.Brand>>();
            //services.AddTransient<IRepository<int, Core.Brand>, BrandRepository>();

            services.AddTransient<ICategoryAppServices, CategoryAppServices>();
            services.AddTransient<IRepository<int, Core.Category>, Repository<int, Core.Category>>();
            //services.AddTransient<IRepository<int, Core.Category>, CategoryRepository>();

            services.AddTransient<IProductAppServices, ProductAppServices>();
            services.AddTransient<IRepository<int, Core.Product>, ProductRepository> ();


            services.AddAutoMapper(typeof(ManagerCollection.ApplicationServices.MapperProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ManagerCollectionContext context)
        {
            app.UseSerilogRequestLogging();

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManagerCollection.WebAPI v1"));
            context.Database.Migrate();


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
