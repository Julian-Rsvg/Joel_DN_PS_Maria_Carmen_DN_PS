using ManagerCollection.Core;
using ManagerCollection.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices.Collections
{
    public class ProductAppServices : IProductAppServices
    {
        private readonly ManagerCollectionContext _dataContext;

        //protected ManagerCollectionContext Context { get => _dataContext; }

        public ProductAppServices(ManagerCollectionContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(int id)
        {
            var entity = _dataContext.ProductsType.Find(id);
            _dataContext.ProductsType.Remove(entity);

            _dataContext.SaveChanges();
        }

        public Product Get(int id)
        {
            var entity = _dataContext.ProductsType.Find(id);
            return entity;
        }

        public List<Product> GetAll()
        {
            var result = _dataContext.ProductsType.ToList();
            return result;
        }

        public void Insert(Product product)
        {
            var brand = _dataContext.Brands.Find(product.Brand.Id);
            var category = _dataContext.Categories.Find(product.Category.Id);

            product.Brand = null;
            product.Category = null;

            _dataContext.ProductsType.Add(product);

            brand.Products.Add(product);
            category.Products.Add(product);

            _dataContext.SaveChanges();
            
        }

        public void Update(Product product)
        {
            var brand = _dataContext.Brands.Find(product.Brand.Id);
            var category = _dataContext.Categories.Find(product.Category.Id);


            var entity = _dataContext.ProductsType.Find(product.Id);

            //entity.Name = product.Name;
            //entity.Category = product.Category;
            //entity.Brand = product.Brand;

            entity.Name = product.Name;
            entity.Category = category;
            entity.Brand = brand;

            _dataContext.SaveChanges();
        }
    }
}
