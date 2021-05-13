using AutoMapper;
using BLL.DTO;
using DAL.Entities;
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

        public UserDTO AttachUser(UserDTO user)
        {
            var res = _userRepository.Attach(FromUserDto(user));
            return ToUserDto(res);
        }

        public UserDTO GetUserById(int id)
        {
            return ToUserDto(_userRepository.GetById(id));
        }

        public UserDTO ToUserDto(User user)
        {
            return _mapper.Map<User, UserDTO>(user);
        }

        public User FromUserDto(UserDTO user)
        {
            return _mapper.Map<UserDTO, User>(user);
        }
    }
}