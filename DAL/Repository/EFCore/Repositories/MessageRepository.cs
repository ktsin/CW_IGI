using System;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repository.EFCore.Repositories
{
    public class MessageRepository : Interfaces.IMessageRepository
    {
        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetBySelector(Func<Message, bool> selector)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Message obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Message obj)
        {
            throw new NotImplementedException();
        }
    }
}