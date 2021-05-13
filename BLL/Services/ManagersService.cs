using AutoMapper;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class ManagersService
    {
        private readonly IManagersRepository _managersRepository = null;
        private readonly IUserRepository _userRepository = null;
        private readonly IMapper _mapper = null;

        public ManagersService(IUserRepository userRepository, IManagersRepository managersRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _managersRepository = managersRepository;
            _mapper = mapper;
        }
    }
}