using NUnit.Framework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerCollection.Core;
using ManagerCollection.ApplicationServices.Collections.Products;
using ManagerCollection.Collection.Dto;
using ManagerCollection.ApplicationServices.Collections;
using ManagerCollection.ApplicationServices.Collections.Categories;

namespace ManagerCollection.UnitTest
{
    [TestFixture]
    public class ProductTest
    {
        protected TestServer server;
        private int IdProduct;

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Order(0)]
        [Test]
        public async Task PostProduct_should()
        {
            Brand brand = new Brand
            {
                Id = 1,
                Name = "Sonrix"
            };
            var repo = server.Host.Services.GetService<IBrandAppServices>();
            var rs = repo.AddBrandAsync(brand);

            Category category = new Category
            {
                Id = 1,
                Name = "Dulces"
            };
            var repo2 = server.Host.Services.GetService<ICategoryAppServices>();
            var rs2 = await repo2.AddCategoryAsync(category);

            Product product = new Product
            {
                Id = 1,
                Name = "Payaso",
                Brand = new Brand { Id = 1},
                Category = new Category { Id = 1}
            };
            var repository = server.Host.Services.GetService<IProductAppServices>();
            var result = await repository.AddProductAsync(product);
            IdProduct = result;
            Assert.AreEqual(1, IdProduct);
        }

        [Order(1)]
        [Test]
        public async Task GetAllProducts()
        {
            var repository = server.Host.Services.GetService<IProductAppServices>();
            var result = await repository.GetProductsAsync();
            Assert.AreEqual(1, result.Count);
        }

        [Order(2)]
        [Test]
        public async Task GetByIdProduct_Test()
        {
            var repository = server.Host.Services.GetService<IProductAppServices>();
            ProductDto result = await repository.GetProductAsync(IdProduct);
            Assert.AreEqual(1, result.Id);
        }

        [Order(3)]
        [Test]
        public async Task PutProduct_Test()
        {
            Product category = new Product
            {
                Id = 1,
                Name = "Paletas"
            };
            var repository = server.Host.Services.GetService<IProductAppServices>();
            var result = repository.EditProductAsync(category);
            ProductDto productId = await repository.GetProductAsync(IdProduct);
            Assert.AreEqual(1, productId.Id);
        }

        [Order(4)]
        [Test]
        public async Task DeleteProduct_Test()
        {
            var repository = server.Host.Services.GetService<IProductAppServices>();
            await repository.DeleteProductAsync(IdProduct);
            ProductDto productId = await repository.GetProductAsync(IdProduct);
            Assert.IsNull(productId);
        }
    }
}
