using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class OrderDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<GoodDTO> Goods { get; set; }

        //Buyer
        public int UserId { get; set; }

        public string Notes { get; set; }

        public bool IsDone { get; set; } = false;

        public ShipmentOptions ShipmentOptions { get; set; } = ShipmentOptions.SelfShipment;
        
        public OrderState State { get; set; } = OrderState.Placed;
        
        public DateTime OrderDate { get; set; }
    }
}