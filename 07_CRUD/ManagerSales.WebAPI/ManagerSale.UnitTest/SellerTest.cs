using ManagerSale.ApplicationServices.Sales.Sell;
using ManagerSale.Core;
using ManagerSale.Sales.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ManagerSale.UnitTest
{
    [TestFixture]
    public class SellerTest
    {
        protected TestServer server;
        private int IdSeller;

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Order(0)]
        [Test]
        public async Task PostSeller_should()
        {
            Seller seller = new Seller
            {
                Id = 1,
                Name = "Lorena",
                LastName ="Guerrero",
                Email = "lorena@test.com",
                Password = "#$%46466slL_R"
            };
            var repository = server.Host.Services.GetService<ISellerAppServices>();
            var result = await repository.AddSellerAsync(seller);
            IdSeller = result;
            Assert.AreEqual(1, IdSeller);
        }

        [Order(1)]
        [Test]
        public async Task GetAllSellers()
        {
            var repository = server.Host.Services.GetService<ISellerAppServices>();
            var result = await repository.GetSellersAsync();
            Assert.AreEqual(1, result.Count);
        }

        [Order(2)]
        [Test]
        public async Task GetByIdSeller_Test()
        {
            var repository = server.Host.Services.GetService<ISellerAppServices>();
            SellerDto result = await repository.GetSellerAsync(IdSeller);
            Assert.AreEqual(1, result.Id);
        }

        [Order(3)]
        [Test]
        public async Task PutSeller_Test()
        {
            Seller seller = new Seller
            {
                Id = 1,
                Name = "Laura",
                LastName = "Torres",
                Email = "laura@test.com",
                Password = "#7888ur_#"
            };
            var repository = server.Host.Services.GetService<ISellerAppServices>();
            var result = repository.EditSellerAsync(seller);
            SellerDto sellerId = await repository.GetSellerAsync(IdSeller);
            Assert.AreEqual(1, sellerId.Id);
        }

        [Order(4)]
        [Test]
        public async Task DeleteSeller_Test()
        {
            var repository = server.Host.Services.GetService<ISellerAppServices>();
            await repository.DeleteSellerAsync(IdSeller);
            SellerDto sellerId = await repository.GetSellerAsync(IdSeller);
            Assert.IsNull(sellerId);
        }
    }
}