using ManagerSale.Core;
using ManagerSale.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Sales
{
    public class SaleProductAppServices : ISaleProductAppServices
    {
        private readonly ManagerSalesContext _dataContext;

        public SaleProductAppServices(ManagerSalesContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(int id)
        {
            var entity = _dataContext.SaleProducts.Find(id);
            _dataContext.SaleProducts.Remove(entity);

            _dataContext.SaveChanges();
        }

        public SaleProduct Get(int id)
        {
            var entity = _dataContext.SaleProducts.Find(id);
            return entity;
        }

        public List<SaleProduct> GetAll()
        {
            var result = _dataContext.SaleProducts.ToList();
            return result;
        }

        public void Insert(SaleProduct saleProduct)
        {
            var seller = _dataContext.Sellers.Find(saleProduct.Seller.Id);
            var product = _dataContext.ProductsType.Find(saleProduct.Product.Id);

            saleProduct.Seller = null;
            saleProduct.Product = null;

            _dataContext.SaleProducts.Add(saleProduct);

            seller.Sales.Add(saleProduct);
            product.Sales.Add(saleProduct);

            _dataContext.SaveChanges();
        }

        public void Update(SaleProduct saleProduct)
        {
            var seller = _dataContext.Sellers.Find(saleProduct.Seller.Id);
            var product = _dataContext.ProductsType.Find(saleProduct.Product.Id);

            var entity = _dataContext.SaleProducts.Find(saleProduct.Id);

            entity.Product = product;
            entity.Seller = seller;
            entity.Price = saleProduct.Price;
            entity.Quantity = saleProduct.Quantity;


            _dataContext.SaveChanges();
        }
    }
}
