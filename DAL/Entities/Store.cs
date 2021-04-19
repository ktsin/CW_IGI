using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Entities
{
    public class Store
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [ForeignKey("User.Id")]
        public int OwnerId { get; set; }
        
        public List<Managers> Managers { get; set; }
        
        public string Address { get; set; }
        
        public byte Rating { get; set; }
        
        public bool IsActive { get; set; }
    }
}