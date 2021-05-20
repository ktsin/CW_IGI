using System.Collections.Generic;
using BLL.DTO;

namespace WUI.Models
{
    public class ManagersViewModel
    {
        public IEnumerable<BLL.DTO.StoreDTO> AssignedStores { get; set; }
        
        public IEnumerable<BLL.DTO.OrderDTO> OrdersToProcess { get; set; }
        
        public OrderState States { get; set; }
    }
}