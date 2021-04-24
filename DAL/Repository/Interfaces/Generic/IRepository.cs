using System;
using System.Collections;
using System.Collections.Generic;

namespace DAL.Repository.Interfaces.Generic
{
    public interface IRepository<T> where T : class
    {
        //CRUD
        public T GetById(int id);

        public IEnumerable<T> GetAll();

        public IEnumerable<T> GetBySelector(Func<T, bool> selector);

        public bool Remove(int id);

        public bool Add(T obj);

        public bool Update(T obj);
    }
}