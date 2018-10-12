using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{

    public class ClientService : IClientService
    {

        private readonly PersistenceDbContext _persistenceDbContext;

        public ClientService(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }


        // CRUD
        public bool Add(Client model)
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
                _persistenceDbContext.Remove(new Client { ClientId = id }).State
                    = EntityState.Deleted;
                _persistenceDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Client Get(int id)
        {
            var result = new Client();

            try
            {
                result = _persistenceDbContext.Clients.Find(
                    id
                 );
                
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public IEnumerable<Client> GetAll()
        {
            var result = new List<Client>();

            try
            {
                result = _persistenceDbContext.Clients.
                    //Include(s => s.Sales).
                    ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public bool Update(Client model)
        {
            try
            {
                var originalModel = _persistenceDbContext.Clients.Single(
                        x => x.ClientId == model.ClientId  
                  );
                
                originalModel.Dni = model.Dni;
                originalModel.Name = model.Name;
                originalModel.LastName = model.LastName;
                originalModel.Phone = model.Phone;
                originalModel.Email = model.Email;
                originalModel.Sex = model.Sex;
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
