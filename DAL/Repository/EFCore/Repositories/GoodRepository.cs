using System;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repository.EFCore.Repositories
{
    public class GoodRepository : Interfaces.IGoodRepository
    {
        public Good GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Good> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Good> GetBySelector(Func<Good, bool> selector)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Good obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Good obj)
        {
            throw new NotImplementedException();
        }
    }
}