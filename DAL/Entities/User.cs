using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        [MinLength(4)] public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public string PhotoPath { get; set; }
    }
}