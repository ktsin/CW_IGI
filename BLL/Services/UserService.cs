using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository = null;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}