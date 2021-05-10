using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class ManagersService
    {
        private readonly IManagersRepository _managersRepository = null;

        public ManagersService(IManagersRepository managersRepository)
        {
            _managersRepository = managersRepository;
        }
    }
}