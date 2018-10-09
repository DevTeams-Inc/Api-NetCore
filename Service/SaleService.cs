using Microsoft.EntityFrameworkCore;
using Model;
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
                _persistenceDbContext.Remove(new Sale { SaleId = id }).State
                    = EntityState.Deleted;
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
                    .Include( p => p.Product)
                    .Include( c => c.Client )
                    .Include( u => u.User )
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public bool Update(Sale model)
        {
            try
            {
                var originalModel = _persistenceDbContext.Sales.Single(
                        x => x.SaleId == model.SaleId
                    );

                originalModel.Product = model.Product;
                originalModel.User = model.User;
                originalModel.Client = model.Client;
                originalModel.ProductId = model.ProductId;
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
    }
}
