using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;
using Npgsql.NodaTime;

namespace DAL.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        [MinLength(4)] public string Name { get; set; }

        public string Address { get; set; }

        public string PhotoPath { get; set; }
    }
}