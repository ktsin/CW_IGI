using System;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.EFCore.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public Store GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetBySelector(Func<Store, bool> selector)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Store obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Store obj)
        {
            throw new NotImplementedException();
        }
    }
}