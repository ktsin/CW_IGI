using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 168

namespace DAL.Repository.EFCore.Repositories
{
    public class CategoryRepository : Interfaces.ICategoryRepository
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

        public IEnumerable<Category> GetAllInclude()
        {
            return GetAll();
        }

        public IEnumerable<Category> GetBySelector(Func<Category, bool> selector)
        {
            return _context.Categories.Where(selector);
        }

        public bool Remove(int id)
        {
            var res = true;
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
            var res = true;
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
            var res = true;
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