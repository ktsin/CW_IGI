using DAL.Entities;
using DAL.Repository.Interfaces.Generic;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User Attach(User user);
    }
}