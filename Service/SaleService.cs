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

        //revisar los Includes
        public IEnumerable<Sale> GetAll()
        {
            var result = new List<Sale>();

            try
            {
                result = _persistenceDbContext.Sales
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        //Cambios revisar
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

                    //var newQuantity = _systemDbContextVentas.productos.Find(sp.Productos);
                    //newQuantity.CantidadProducto = newQuantity.CantidadProducto - p.CantidadProducto;
                    //_systemDbContextVentas.productos.Update(newQuantity);
                    //_systemDbContextVentas.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


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
    }
}
