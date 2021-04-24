using System;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repository.EFCore.Repositories
{
    public class OrderRepository : Interfaces.IOrderRepository
    {
        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetBySelector(Func<Order, bool> selector)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Order obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}