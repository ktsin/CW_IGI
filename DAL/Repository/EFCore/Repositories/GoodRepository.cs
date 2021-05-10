using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.EFCore.Repositories
{
    public class GoodRepository : Interfaces.IGoodRepository
    {
        private readonly DataContext _context = null;

        public GoodRepository(DataContext context)
        {
            _context = context;
        }

        public Good GetById(int id)
        {
            return _context.Goods.Find(id);
        }

        public IEnumerable<Good> GetAll()
        {
            return _context.Goods;
        }

        public IEnumerable<Good> GetAllInclude()
        {
            return GetAll();
        }

        public IEnumerable<Good> GetBySelector(Func<Good, bool> selector)
        {
            return _context.Goods.Where(selector);
        }

        public bool Remove(int id)
        {
            var isOk = true;
            try
            {
                var obj = _context.Goods.Find(id);
                _context.Goods.Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                isOk = false;
            }

            return isOk;
        }

        public bool Add(Good obj)
        {
            var isOk = true;
            try
            {
                _context.Goods.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                isOk = false;
            }

            return isOk;
        }

        public bool Update(Good obj)
        {
            var isOk = true;
            try
            {
                var sub = _context.Goods.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                isOk = false;
            }

            return isOk;
        }
    }
}