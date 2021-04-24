using System;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetBySelector(Func<User, bool> selector)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(User obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}