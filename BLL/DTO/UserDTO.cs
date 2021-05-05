using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class UserDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(4)] public string Name { get; set; }

        public string Birtday { get; set; }
        
        public string RegistrationDay { get; set; }
        
        public string Address { get; set; }

        public string PhotoPath { get; set; }
    }
}