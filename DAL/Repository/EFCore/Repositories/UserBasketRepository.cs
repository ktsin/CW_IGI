using System;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.EFCore.Repositories
{
    public class UserBasketRepository : IUserBasketRepository
    {
        public UserBasket GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserBasket> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserBasket> GetBySelector(Func<UserBasket, bool> selector)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(UserBasket obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserBasket obj)
        {
            throw new NotImplementedException();
        }
    }
}