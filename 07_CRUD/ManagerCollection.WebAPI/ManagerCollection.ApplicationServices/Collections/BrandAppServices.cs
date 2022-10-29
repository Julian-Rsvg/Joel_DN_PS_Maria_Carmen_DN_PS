using ManagerCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagerCollection.EntityFramework;

namespace ManagerCollection.ApplicationServices.Collections
{
    public class BrandAppServices : IBrandAppServices
    {
        private readonly ManagerCollectionContext _dataContext;

        public BrandAppServices(ManagerCollectionContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(Brand brand)
        {
            _dataContext.Brands.Add(brand);
            _dataContext.SaveChanges();
        }

        public void Update(Brand brand)
        {
            var entity = _dataContext.Brands.Find(brand.Id);
            
            entity.Name = brand.Name;

            _dataContext.SaveChanges();
        }

        public Brand Get(int id)
        {
            var entity = _dataContext.Brands.Find(id);
            return entity;
        }

        public List<Brand> GetAll()
        {
            var result = _dataContext.Brands.ToList();
            return result;
        } 

        public void Delete(int id)
        {
            var entity = _dataContext.Brands.Find(id);
            _dataContext.Brands.Remove(entity);

            _dataContext.SaveChanges();
        }


    }
}
