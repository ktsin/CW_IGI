using AutoMapper;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class GoodsService
    {
        private readonly IGoodRepository _goodRepository = null;
        private readonly IMapper _mapper = null;

        public GoodsService(IGoodRepository goodRepository,
            IMapper mapper)
        {
            _goodRepository = goodRepository;
            _mapper = mapper;
        }
    }
}