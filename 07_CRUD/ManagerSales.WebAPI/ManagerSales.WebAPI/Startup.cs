using GymManager.DataAccess.Repositories;
using ManagerSale.ApplicationServices.Sales.Sell;
//using ManagerSale.ApplicationServices.Sales.SP;
using ManagerSale.Core;
using ManagerSale.EntityFramework;
using ManagerSale.EntityFramework.Repositories;
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
using ManagerSale.ApplicationServices.Collection;
using ManagerSale.ApplicationServices.Sales.S;
using System.Net.Http;

namespace ManagerSales.WebAPI
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
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManagerSales.WebAPI", Version = "v1" });
            });


            services.AddTransient<ISellerAppServices, SellerAppServices>();
            services.AddTransient<IRepository<int, ManagerSale.Core.Seller>, SellerRepository>();
            
            services.AddTransient<IProductCollectionAppService, ProductCollectionAppService>();

            services.AddTransient<ISaleAppService, SaleAppService>();
            services.AddTransient<IRepository<int, ManagerSale.Core.SaleProduct>, SaleProductRepository>();
            //services.AddTransient<IRepository<int, ManagerSale.Core.SaleProduct>, Repository<int, ManagerSale.Core.SaleProduct>>();


            services.AddHttpClient("product", client =>
            {
                client.BaseAddress = new Uri(Configuration["AppSetting:productUrlBase"]);
            }).ConfigurePrimaryHttpMessageHandler((c)=>
                new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                }
            );

            services.AddAutoMapper(typeof(ManagerSale.ApplicationServices.MapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ManagerSalesContext context)
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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManagerSales.WebAPI v1"));
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
