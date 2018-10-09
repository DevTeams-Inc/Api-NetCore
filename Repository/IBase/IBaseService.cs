using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices.IBase
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Add(T model);
        bool Delete(int id);
        bool Update(T model);
    }
}
