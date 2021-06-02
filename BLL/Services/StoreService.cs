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
        private readonly IManagersRepository _managers = null;
        private readonly IMapper _mapper = null;

        public StoreService(IStoreRepository stores,
            IMapper mapper,
            IManagersRepository managers)
        {
            _stores = stores;
            _mapper = mapper;
            _managers = managers;
        }

        public bool RegisterStore(StoreDTO store)
        {
            return _stores.Add(FromStoreDto(store));
        }

        public bool DeleteStore(int id)
        {
            return _stores.Remove(id);
        }

        public bool EditStore(StoreDTO newStore)
        {
            return _stores.Update(FromStoreDto(newStore));
        }

        public IEnumerable<ManagersDTO> GetAllManagers()
        {
            return _managers.GetAll().Select(ToManagersDto);
        }
        
        public IEnumerable<ManagersDTO> GetManagersByStore(int storeId)
        {
            return _managers.GetBySelector(e=>e?.StoreId == storeId)?.Select(ToManagersDto);
        }
        
        public IEnumerable<ManagersDTO> GetStoreByManager(int managerId)
        {
            return _managers.GetBySelector(e=>e?.UserId == managerId)?.Select(ToManagersDto);
        }

        public IEnumerable<StoreDTO> GetAllStores()
        {
            return _stores.GetAllInclude().Select(ToStoreDto);
        }

        public StoreDTO GetStoreById(int id)
        {
            return ToStoreDto(_stores.GetById(id));
        }

        public bool AssignManager(ManagersDTO manager)
        {
            return _managers.Add(FromManagersDto(manager));
        }
        
        public StoreDTO ToStoreDto(Store msg)
        {
            return _mapper.Map<Store, StoreDTO>(msg);
        }
        
        public Store FromStoreDto(StoreDTO msg)
        {
            return _mapper.Map<StoreDTO, Store>(msg);
        }
        
        public ManagersDTO ToManagersDto(Managers msg)
        {
            return _mapper.Map<Managers, ManagersDTO>(msg);
        }
        
        public Managers FromManagersDto(ManagersDTO msg)
        {
            return _mapper.Map<ManagersDTO, Managers>(msg);
        }
    }
}