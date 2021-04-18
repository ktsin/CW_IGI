using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }
        
        public List<Good> Goods { get; set; }
        //Buyer
        public ulong UserId { get; set; }
        
        public string Notes { get; set; }

        public bool IsDone { get; set; } = false;

        public ShipmentOptions ShipmentOptions { get; set; } = ShipmentOptions.SelfShipment;
    }
}