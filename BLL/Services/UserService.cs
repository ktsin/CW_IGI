using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IUserBasketRepository basketRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _basketRepository = basketRepository;
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

        public BLL.DTO.UserBasket GetBasketByUser(int userId)
        {
            var b = _basketRepository
                .GetBySelector(e => e.UserId == userId)
                .FirstOrDefault();
            var bd = ToUserBasketDto(b);
            return bd;
        }

        public void CleanBasketByUserId(int userId)
        {
            var b = _basketRepository
                .GetBySelector(e => e.UserId == userId)
                .FirstOrDefault();
            b.SelectedGoods = new List<Good>();
            _basketRepository.Update(b);
        }

        public UserDTO ToUserDto(User user)
        {
            return _mapper.Map<User, UserDTO>(user);
        }

        public User FromUserDto(UserDTO user)
        {
            return _mapper.Map<UserDTO, User>(user);
        }
        
        public DTO.UserBasket ToUserBasketDto(DAL.Entities.UserBasket basket)
        {
            return _mapper.Map<DAL.Entities.UserBasket, DTO.UserBasket>(basket);
        }

        public DAL.Entities.UserBasket FromUserBasketDto(DTO.UserBasket basket)
        {
            return _mapper.Map<DTO.UserBasket, DAL.Entities.UserBasket>(basket);
        }
    }
}