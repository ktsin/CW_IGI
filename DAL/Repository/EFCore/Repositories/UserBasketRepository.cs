using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 168

namespace DAL.Repository.EFCore.Repositories
{
    public class UserBasketRepository : IUserBasketRepository
    {
        private readonly DataContext _context = null;

        public UserBasketRepository(DataContext context)
        {
            _context = context;
        }

        public UserBasket GetById(int id)
        {
            return _context.UserBaskets.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<UserBasket> GetAll()
        {
            return _context.UserBaskets;
        }

        public IEnumerable<UserBasket> GetAllInclude()
        {
            return _context.UserBaskets.Include(e => e.SelectedGoods);
        }

        public IEnumerable<UserBasket> GetBySelector(Func<UserBasket, bool> selector)
        {
            return _context.UserBaskets.Where(selector);
        }

        public bool Remove(int id)
        {
            var res = true;
            try
            {
                _context.UserBaskets.Remove(_context.UserBaskets.Find(id));
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }

        public bool Add(UserBasket obj)
        {
            var res = true;
            try
            {
                _context.UserBaskets.Add(obj);
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }

        public bool Update(UserBasket obj)
        {
            var res = true;
            try
            {
                _context.UserBaskets.Update(obj);
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }
    }
}