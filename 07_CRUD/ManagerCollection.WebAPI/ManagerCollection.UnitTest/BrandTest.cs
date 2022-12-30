using ManagerCollection.ApplicationServices.Collections;
using ManagerCollection.Collection.Dto;
using ManagerCollection.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ManagerCollection.UnitTest
{
    [TestFixture]
    public class BrandTest
    {
        protected TestServer server;
        private int IdBrand;

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Order(0)]
        [Test]
        public async Task PostBrand_should()
        {
            BrandAddDto brand = new BrandAddDto
            {
                Name = "Alpura"
            };
            var repository = server.Host.Services.GetService<IBrandAppServices>();
            var result = repository.AddBrandAsync(brand);
            IdBrand = result.Id;
            Assert.AreEqual(1, IdBrand);
        }

        [Order(1)]
        [Test]
        public async Task GetAllBrands()
        {
            var repository = server.Host.Services.GetService<IBrandAppServices>();
            var result = await repository.GetBrandsAsync();
            Assert.AreEqual(1, result.Count);
        }

        [Order(2)]
        [Test]
        public async Task GetByIdBran_Test()
        {
            var repository = server.Host.Services.GetService<IBrandAppServices>();
            BrandDto result = await repository.GetBrandAsync(IdBrand);
            Assert.AreEqual(1,result.Id);
        }

        [Order(3)]
        [Test]
        public async Task PutBrand_Test()
        {
            BrandAddDto brand = new BrandAddDto
            {
                Name = "Aurelita"
            };
            var repository = server.Host.Services.GetService<IBrandAppServices>();
            var result = repository.EditBrandAsync(brand);
            BrandDto brandId = await repository.GetBrandAsync(IdBrand);
            Assert.AreEqual(1, brandId.Id);
        }

        [Order(4)]
        [Test]
        public async Task DeleteBrand_Test()
        {
            var repository = server.Host.Services.GetService<IBrandAppServices>();
            await repository.DeleteBrandAsync(IdBrand);
            BrandDto brandId = await repository.GetBrandAsync(IdBrand);
            Assert.IsNull(brandId);
        }
    }
}