using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class ManagersDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StoreId { get; set; }
        public int UserId { get; set; }
    }
}