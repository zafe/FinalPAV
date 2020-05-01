using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        T GetById(object id);
        List<T> GetAll();

    }
}
