using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerSale.ApplicationServices.Sales.S;
using ManagerSale.ApplicationServices.Sales.Sell;
using ManagerSale.Core;
using ManagerSale.Sales.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ManagerSale.UnitTest
{
    [TestFixture]
    public class SaleTest
    {
        protected TestServer server;
        private int IdSale;

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Order(0)]
        [Test]
        public async Task PostSale_should()
        {
            SellerAddDto seller = new SellerAddDto
            {
                Name = "Lorena",
                LastName = "Guerrero",
                Email = "lorena@test.com",
                Password = "#$%46466slL_R"
            };
            var repo = server.Host.Services.GetService<ISellerAppServices>();
            var rs = repo.AddSellerAsync(seller);

            SaleProductAddDto sale = new SaleProductAddDto
            {
                SellerId = 1,
                ProductId = 1,
                Quantity = 1,
                Price = 10.00
            };
            var repository = server.Host.Services.GetService<ISaleAppService>();
            var result = repository.AddSaleProductAsync(sale);
            IdSale = result.Id;
            Assert.AreEqual(1, IdSale);
        }

        [Order(1)]
        [Test]
        public async Task GetAllSales()
        {
            var repository = server.Host.Services.GetService<ISaleAppService>();
            var result = await repository.GetSaleProductsAsync();
            Assert.AreEqual(1, result.Count);
        }

        [Order(2)]
        [Test]
        public async Task GetByIdSale_Test()
        {
            var repository = server.Host.Services.GetService<ISaleAppService>();
            SaleProductDto result = await repository.GetSaleProductAsync(IdSale);
            Assert.AreEqual(1, result.Id);
        }

        [Order(3)]
        [Test]
        public async Task PutSale_Test()
        {
            SaleProductAddDto sale = new SaleProductAddDto
            {
                SellerId = 1,
                ProductId = 2,
                Quantity = 1,
                Price = 20.00
            };
            var repository = server.Host.Services.GetService<ISaleAppService>();
            var result = repository.EditSaleProductAsync(sale);
            SaleProductDto saleId = await repository.GetSaleProductAsync(IdSale);
            Assert.AreEqual(1, saleId.Id);
        }

        [Order(4)]
        [Test]
        public async Task DeleteSale_Test()
        {
            var repository = server.Host.Services.GetService<ISaleAppService>();
            await repository.DeleteSaleProductAsync(IdSale);
            SaleProductDto saleId = await repository.GetSaleProductAsync(IdSale);
            Assert.IsNull(saleId);
        }
    }
}
