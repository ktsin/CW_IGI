using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class StoreDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = int.MinValue;

        public string Name { get; set; }

        public string Description { get; set; }

        public int OwnerId { get; set; }

        public string Address { get; set; }

        public byte Rating { get; set; }

        public bool IsActive { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}