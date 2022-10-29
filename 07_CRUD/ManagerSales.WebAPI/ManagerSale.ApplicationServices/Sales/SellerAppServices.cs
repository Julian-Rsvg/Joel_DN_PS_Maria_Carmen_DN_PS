using ManagerSale.Core;
using ManagerSale.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Sales
{
    public class SellerAppServices : ISellerAppServices
    {
        private readonly ManagerSalesContext _dataContext;

        public SellerAppServices(ManagerSalesContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(int id)
        {
            var entity = _dataContext.Sellers.Find(id);
            _dataContext.Sellers.Remove(entity);

            _dataContext.SaveChanges();
        }

        public Seller Get(int id)
        {
            var entity = _dataContext.Sellers.Find(id);
            return entity;
        }

        public List<Seller> GetAll()
        {
            var result = _dataContext.Sellers.ToList();
            return result;
        }

        public void Insert(Seller seller)
        {
            _dataContext.Sellers.Add(seller);
            _dataContext.SaveChanges();
        }

        public void Update(Seller seller)
        {
            var entity = _dataContext.Sellers.Find(seller.Id);

            entity.Name = seller.Name;
            entity.Email = seller.Email;
            entity.LastName = seller.LastName;
            entity.Password = seller.Password;

            _dataContext.SaveChanges();
        }
    }
}
