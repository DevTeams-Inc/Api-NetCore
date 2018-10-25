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

    public class SupplierService : ISupplierService
    {

        private readonly PersistenceDbContext _persistenceDbContext;

        public SupplierService(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }

        //CRUD
        public bool Add(Supplier model)
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
                _persistenceDbContext.Remove(new Supplier { SupplierId = id }).State
                    = EntityState.Deleted;
                _persistenceDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Supplier Get(int id)
        {
            var result = new Supplier();
            try
            {
                result = _persistenceDbContext.Suppliers.Single(
                        x => x.SupplierId == id
                    );
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public IEnumerable<Supplier> GetAll()
        {
            var result = new List<Supplier>();

            try
            {
                result = _persistenceDbContext.Suppliers.
                    ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public List<Supplier> Search(string param)
        {
            var result = new List<Supplier>();
            try
            {
                result = _persistenceDbContext.Suppliers
                        .Where(x =>
                        x.Name.Contains(param) || x.Dni.Contains(param))
                        .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool Update(Supplier model)
        {
            try
            {
                var originalModel = _persistenceDbContext.Suppliers.Single(
                        x => x.SupplierId == model.SupplierId
                    );

                originalModel.Dni = model.Dni;
                originalModel.Name = model.Name;
                originalModel.Phone = model.Phone;
                originalModel.Address = model.Address;
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
