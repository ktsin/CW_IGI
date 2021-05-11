using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class StoreService
    {
        private readonly IStoreRepository _stores = null;
        private readonly IMapper _mapper = null;

        public StoreService(IStoreRepository stores, IMapper mapper)
        {
            _stores = stores;
            _mapper = mapper;
        }

        public bool RegisterStore(StoreDTO store)
        {
            return _stores.Add(null);
        }
    }
}