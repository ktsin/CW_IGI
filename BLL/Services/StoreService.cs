using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

        public bool DeleteStore(int id)
        {
            return _stores.Remove(id);
        }

        public bool EditStore(StoreDTO newStore)
        {
            return _stores.Update(FromStoreDto(newStore));
        }

        public IEnumerable<StoreDTO> GetAllStores()
        {
            return _stores.GetAllInclude().Select(ToStoreDto);
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