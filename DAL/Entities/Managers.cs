using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Managers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StoreId { get; set; }
        public int UserId { get; set; }
    }
}