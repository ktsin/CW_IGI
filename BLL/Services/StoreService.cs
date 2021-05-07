using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class StoreService
    {
        private readonly IStoreRepository _stores = null;
        public StoreService(IStoreRepository stores)
        {
            _stores = stores;
        }

        public bool RegisterStore(StoreDTO store)
        {
            return _stores.Add(null);
        }
    }
}