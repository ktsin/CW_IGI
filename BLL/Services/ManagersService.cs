using AutoMapper;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class ManagersService
    {
        private readonly IManagersRepository _managersRepository = null;
        private readonly IMapper _mapper = null;

        public ManagersService(IManagersRepository managersRepository, IMapper mapper)
        {
            _managersRepository = managersRepository;
            _mapper = mapper;
        }
    }
}