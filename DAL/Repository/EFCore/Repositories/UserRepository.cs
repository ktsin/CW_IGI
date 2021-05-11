using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 168

namespace DAL.Repository.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context = null;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetAllInclude()
        {
            return GetAll();
        }

        public IEnumerable<User> GetBySelector(Func<User, bool> selector)
        {
            return _context.Users.Where(selector);
        }

        public bool Remove(int id)
        {
            var isOk = true;
            try
            {
                var subject = _context.Users.FirstOrDefault(e => e.Id == id);
                _context.Users.Remove(subject);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                isOk = false;
            }

            return isOk;
        }

        public bool Add(User obj)
        {
            var isOk = true;
            try
            {
                _context.Users.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                isOk = false;
            }

            return isOk;
        }

        public bool Update(User obj)
        {
            var isOk = true;
            try
            {
                var subject = _context.Users.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                isOk = false;
            }

            return isOk;
        }

        public User Attach(User user)
        {
            var attached = _context.Users.Attach(user);
            _context.SaveChanges();
            return attached.Entity;
        }
    }
}