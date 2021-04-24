using System;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repository.EFCore.Repositories
{
    public class CategoryRepository : DAL.Repository.Interfaces.ICategoryRepository
    {
        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetBySelector(Func<Category, bool> selector)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Category obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}