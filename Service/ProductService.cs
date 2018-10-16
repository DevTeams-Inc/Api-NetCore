using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using Service.IServices;
using Service.IServices.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class ProductService : IProductService
    {

        private readonly PersistenceDbContext _persistenceDbContext;

        public ProductService(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }


        //CRUD 
        public bool Add(Product model)
        {
            try
            {
                _persistenceDbContext.Add(model);
                _persistenceDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                var model = _persistenceDbContext.Products.Single(x => x.ProductId == id);
                _persistenceDbContext.Remove(model);
                _persistenceDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return true;
            }

            return false;
        }

        public Product Get(int id)
        {
            var result = new Product();

            try
            {
                result = _persistenceDbContext.Products.Single(
                        x => x.ProductId == id
                    );
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public IEnumerable<Product> GetAll()
        {
            var result = new List<Product>();

            try
            {

                result = _persistenceDbContext.Products
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public Product Search(string param)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product model)
        {
            try
            {
                var originalModel = _persistenceDbContext.Products.Single(
                         x => x.ProductId == model.ProductId 
                    );

                originalModel.Supplier = model.Supplier;
                originalModel.Name = model.Name;
                originalModel.ProductCode = model.ProductCode;
                originalModel.Type = model.Type;
                originalModel.Quantity = model.Quantity;
                originalModel.PricePerSale = model.PricePerSale;
                originalModel.PricePerPurchase = model.PricePerPurchase;
                originalModel.UpdatedDate = DateTime.Now;

                _persistenceDbContext.Update(originalModel);
                _persistenceDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        List<Product> IBaseService<Product>.Search(string param)
        {
            throw new NotImplementedException();
        }
    }
}
