using System.Collections.Generic;
using BLL.DTO;

namespace WUI.Models
{
    public class ManagersViewModel
    {
        public IEnumerable<StoreDTO> AssignedStores { get; set; }
        
        public IEnumerable<OrderDTO> OrdersToProcess { get; set; }
        
        public OrderState States { get; set; }
    }
}