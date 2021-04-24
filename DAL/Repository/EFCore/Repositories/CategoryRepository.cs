using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;

namespace DAL.Repository.EFCore.Repositories
{
    public class CategoryRepository : DAL.Repository.Interfaces.ICategoryRepository
    {
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public IEnumerable<Category> GetBySelector(Func<Category, bool> selector)
        {
            return _context.Categories.Where(selector);
        }

        public bool Remove(int id)
        {
            bool res = true;
            try
            {
                _context.Categories.Remove(_context.Categories.Find(id));
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }

        public bool Add(Category obj)
        {
            bool res = true;
            try
            {
                _context.Categories.Add(obj);
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }

        public bool Update(Category obj)
        {
            bool res = true;
            try
            {
                _context.Categories.Update(obj);
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