using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int SenderId { get; set; }
        
        public int RecipientId { get; set; }

        [MaxLength(1023)] public string MessageBody { get; set; }
    }
}