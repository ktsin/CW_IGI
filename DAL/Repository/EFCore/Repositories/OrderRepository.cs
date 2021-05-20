using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 168

namespace DAL.Repository.EFCore.Repositories
{
    public class OrderRepository : Interfaces.IOrderRepository
    {
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public IEnumerable<Order> GetAllInclude()
        {
            return _context.Orders.Include(e => e.Goods);
        }

        public IEnumerable<Order> GetBySelector(Func<Order, bool> selector)
        {
            return _context.Orders.Where(selector);
        }

        public bool Remove(int id)
        {
            var res = true;
            try
            {
                _context.Orders.Remove(_context.Orders.Find(id));
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }

        public bool Add(Order obj)
        {
            var res = true;
            try
            {
                var goods = obj.Goods;
                obj.Goods = new List<Good>();
                obj = _context.Orders.Add(obj).Entity;
                _context.SaveChanges();
                obj.Goods = goods;
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }

        public bool Update(Order obj)
        {
            var res = true;
            try
            {
                _context.Orders.Remove(obj);
                _context.SaveChanges();
                _context.Orders.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }

        private readonly DataContext _context = null;
    }
}