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

    public class UserService : IUserService
    {

        public readonly PersistenceDbContext _persistenceDbContext;

        public UserService(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }

        //CRUD
        public bool Add(User model)
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
                var m = _persistenceDbContext.Users.Single(x => x.UserId == id);
                _persistenceDbContext.Remove(m);
                _persistenceDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public User Get(int id)
        {
            var result = new User();

            try
            {
                result = _persistenceDbContext.Users.Single(
                        x => x.UserId == id
                    );
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();

            try
            {
                result = _persistenceDbContext.Users.ToList();
                
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public bool Update(User model)
        {
            try
            {
                var originalModel = _persistenceDbContext.Users.Single(
                        x => x.UserId == model.UserId
                    );

                originalModel.Name = model.Name;
                originalModel.Phone = model.Phone;
                originalModel.Email = model.Email;
                originalModel.UserName = model.UserName;
                originalModel.Password = model.Password;
                originalModel.Role = model.Role;
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
