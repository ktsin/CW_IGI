using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserBasket
    {
        public int Id { get; set; }
        
        public int UserId { get; set; } 

        public List<Good> SelectedGoods { get; set; }
    }
}