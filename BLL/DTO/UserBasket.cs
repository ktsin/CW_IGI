using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserBasket
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public List<GoodDTO> SelectedGoods { get; set; }
    }
}