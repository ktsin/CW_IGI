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
        
        public StoreDTO ToStoreDto(Store msg)
        {
            return _mapper.Map<Store, StoreDTO>(msg);
        }
        
        public Store FromStoreDto(StoreDTO msg)
        {
            return _mapper.Map<StoreDTO, Store>(msg);
        }
    }
}