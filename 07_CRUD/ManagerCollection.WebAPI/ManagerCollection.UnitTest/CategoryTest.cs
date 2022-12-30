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
using ManagerCollection.ApplicationServices.Collections.Categories;
using ManagerCollection.Collection.Dto;

namespace ManagerCollection.UnitTest
{
    [TestFixture]
    public class CategoryTest
    {
        protected TestServer server;
        private int IdCategory;

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Order(0)]
        [Test]
        public async Task PostCategory_should()
        {
            CategoryAddDto category = new CategoryAddDto
            {
                Name = "Dulces"
            };
            var repository = server.Host.Services.GetService<ICategoryAppServices>();
            var result = repository.AddCategoryAsync(category);
            IdCategory = result.Id;
            Assert.AreEqual(1, IdCategory);
        }

        [Order(1)]
        [Test]
        public async Task GetAllCategoriess()
        {
            var repository = server.Host.Services.GetService<ICategoryAppServices>();
            var result = await repository.GetCategoriesAsync();
            Assert.AreEqual(1, result.Count);
        }

        [Order(2)]
        [Test]
        public async Task GetByIdCategory_Test()
        {
            var repository = server.Host.Services.GetService<ICategoryAppServices>();
            CategoryDto result = await repository.GetCategoryAsync(IdCategory);
            Assert.AreEqual(1, result.Id);
        }

        [Order(3)]
        [Test]
        public async Task PutCategory_Test()
        {
            CategoryAddDto category = new CategoryAddDto
            {
                Name = "Paletas"
            };
            var repository = server.Host.Services.GetService<ICategoryAppServices>();
            var result = repository.EditCategoryAsync(category);
            CategoryDto categoryId = await repository.GetCategoryAsync(IdCategory);
            Assert.AreEqual(1, categoryId.Id);
        }

        [Order(4)]
        [Test]
        public async Task DeleteCategory_Test()
        {
            var repository = server.Host.Services.GetService<ICategoryAppServices>();
            await repository.DeleteCategoryAsync(IdCategory);
            CategoryDto categoryId = await repository.GetCategoryAsync(IdCategory);
            Assert.IsNull(categoryId);
        }
    }
}
