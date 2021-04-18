using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Managers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }
        public uint StoreId { get; set; } 
        public ulong UserId { get; set; }
    }
}