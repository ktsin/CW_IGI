using AutoMapper;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository = null;
        private readonly IMapper _mapper = null;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
    }
}