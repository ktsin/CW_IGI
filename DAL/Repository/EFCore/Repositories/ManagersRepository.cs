using System;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repository.EFCore.Repositories
{
    public class ManagersRepository : Interfaces.IManagersRepository
    {
        public Managers GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Managers> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Managers> GetBySelector(Func<Managers, bool> selector)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Managers obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Managers obj)
        {
            throw new NotImplementedException();
        }
    }
}