using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 168

namespace DAL.Repository.EFCore.Repositories
{
    public class MessageRepository : Interfaces.IMessageRepository
    {
        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public Message GetById(int id)
        {
            return _context.Messages.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages;
        }

        public IEnumerable<Message> GetAllInclude()
        {
            return GetAll();
        }

        public IEnumerable<Message> GetBySelector(Func<Message, bool> selector)
        {
            return _context.Messages.Where(selector);
        }

        public bool Remove(int id)
        {
            var res = true;
            try
            {
                _context.Messages.Remove(_context.Messages.Find(id));
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }

        public bool Add(Message obj)
        {
            var res = true;
            try
            {
                _context.Messages.Add(obj);
            }
            catch (Exception e)
            {
                res = false;
            }

            return res;
        }

        public bool Update(Message obj)
        {
            var res = true;
            try
            {
                _context.Messages.Update(obj);
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