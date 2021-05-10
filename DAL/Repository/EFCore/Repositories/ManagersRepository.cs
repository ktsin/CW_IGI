using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 168

namespace DAL.Repository.EFCore.Repositories
{
    public class ManagersRepository : Interfaces.IManagersRepository
    {
        public ManagersRepository(DataContext context)
        {
            _context = context;
        }

        public Managers GetById(int id)
        {
            return _context.Managers.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Managers> GetAll()
        {
            return _context.Managers;
        }

        public IEnumerable<Managers> GetAllInclude()
        {
            return GetAll();
        }

        public IEnumerable<Managers> GetBySelector(Func<Managers, bool> selector)
        {
            return _context.Managers.Where(selector);
        }

        public bool Remove(int id)
        {
            var res = true;
            try
            {
                _context.Managers.Remove(_context.Managers.Find(id));
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }

        public bool Add(Managers obj)
        {
            var res = true;
            try
            {
                _context.Managers.Add(obj);
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }

        public bool Update(Managers obj)
        {
            var res = true;
            try
            {
                _context.Managers.Update(obj);
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