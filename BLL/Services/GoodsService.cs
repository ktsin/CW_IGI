using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class GoodsService
    {
        private readonly IGoodRepository _goodRepository = null;

        public GoodsService(IGoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }
    }
}