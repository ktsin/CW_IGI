using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.EFCore.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _context = null;
        public StoreRepository(DataContext context)
        {
            _context = context;
        }
        public Store GetById(int id)
        {
            Store res = null;
            try
            {
                res =  _context.Stores.First(store => store.Id == id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return res;
        }

        public IEnumerable<Store> GetAll()
        {
            return _context.Stores;
        }
        
        public IEnumerable<Store> GetAllFull()
        {
            return GetAll();
        }

        public IEnumerable<Store> GetBySelector(Func<Store, bool> selector)
        {
            return _context.Stores.Where(selector);
        }

        public bool Remove(int id)
        {
            bool res = true;
            try
            {
                _context.Stores.Remove(_context.Stores.Find(id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                res = false;
            }
            return res;
        }

        public bool Add(Store obj)
        {
            bool res = false;
            try
            {
                _context.Stores.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                res = false;
            }
            return res;
        }

        public bool Update(Store obj)
        {
            bool res = false;
            try
            {
                _context.Stores.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                res = false;
            }
            return res;
        }
    }
}