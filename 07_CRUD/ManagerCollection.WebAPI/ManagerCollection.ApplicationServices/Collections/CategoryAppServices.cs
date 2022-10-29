using ManagerCollection.Core;
using ManagerCollection.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCollection.ApplicationServices.Collections
{
    public class CategoryAppServices : ICategoryAppServices
    {
        private readonly ManagerCollectionContext _dataContext;

        public CategoryAppServices(ManagerCollectionContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(int id)
        {
            var entity = _dataContext.Categories.Find(id);
            _dataContext.Categories.Remove(entity);

            _dataContext.SaveChanges();
        }

        public Category Get(int id)
        {
            var entity = _dataContext.Categories.Find(id);
            return entity;
        }

        public List<Category> GetAll()
        {
            var result = _dataContext.Categories.ToList();
            return result;
        }

        public void Insert(Category category)
        {
            _dataContext.Categories.Add(category);
            _dataContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var entity = _dataContext.Categories.Find(category.Id);

            entity.Name = category.Name;

            _dataContext.SaveChanges();
        }
    }
}
