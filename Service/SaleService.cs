using Microsoft.EntityFrameworkCore;
using Model;
using Model.VM;
using Persistence;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class SaleService : ISaleService
    {
        private readonly PersistenceDbContext _persistenceDbContext;
        
        public SaleService(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }

        //CRUD
        public bool Add(Sale model)
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
                var model = _persistenceDbContext.Sales.Single(x => x.SaleId == id);
                _persistenceDbContext.Remove(model);
                _persistenceDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Sale Get(int id)
        {
            var result = new Sale();

            try
            {
                result = _persistenceDbContext.Sales.Single(
                        x => x.SaleId == id
                    );
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public IEnumerable<Sale> GetAll()
        {
            var result = new List<Sale>();
            try
            {
                result = _persistenceDbContext.Sales
                    .Include(x => x.Client)
                    .Include(x => x.User)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool Add(SaleProductVM viewModelPV)
        {
            try
            {
                DateTime today = DateTime.Now;
                viewModelPV.Sale.SaleDate = today;
                _persistenceDbContext.Add(viewModelPV.Sale);
                _persistenceDbContext.SaveChanges();
                var maxID = _persistenceDbContext.Sales.Max(x => x.SaleId);
                SalesProducts sp;
                foreach (var p in viewModelPV.Products)
                {
                    sp = new SalesProducts();
                    sp.SaleId = maxID;
                    sp.ProductId = p.ProductId;
                    sp.Quantity = p.Quantity;
                    _persistenceDbContext.SalesProducts.Add(sp);
                    _persistenceDbContext.SaveChanges();

                    var newQuantity = _persistenceDbContext.Products.Find(p.ProductId);
                    newQuantity.Quantity = newQuantity.Quantity - p.Quantity;
                    _persistenceDbContext.Products.Update(newQuantity);
                    _persistenceDbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //Not is a funtional
        public bool Update(Sale model)
        {
            try
            {
                var originalModel = _persistenceDbContext.Sales.Single(
                        x => x.SaleId == model.SaleId
                    );

                originalModel.User = model.User;
                originalModel.Client = model.Client;
                originalModel.UserId = model.UserId;
                originalModel.ClientId = model.ClientId;
                originalModel.Discount = model.Discount;
                originalModel.SubTotal = model.SubTotal;
                originalModel.Total = model.Total;
                originalModel.SaleDate = model.SaleDate;
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

        public SaleProductVM GetSaleDetail(int id)
        {
            var sl = new SaleProductVM();
            try
            {
                var sale = _persistenceDbContext.SalesProducts
                            .Include(s => s.Product)
                            .Include(s => s.Sale)
                            .Where(s => s.SaleId == id);
                sl.Sale = _persistenceDbContext.Sales
                    .Include(x => x.Client)
                    .Include(x => x.User)
                      .First(s => s.SaleId == id);

                var p = new Product();
                var q = new List<Product>();

                foreach (var i in sale)
                {
                    p = _persistenceDbContext.Products
                        .First(x => x.ProductId == i.ProductId);
                    p.Quantity = i.Quantity;
                    q.Add(p); 
                }
                sl.Products = q;
            }
            catch (Exception)
            {
                throw;
            }
            return sl;
        }

        public List<Sale> Search(string param)
        {
            throw new NotImplementedException();
        }
    }
}
