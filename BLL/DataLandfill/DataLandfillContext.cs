using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DataLandfill
{
    public class DataLandfillContext : DbContext
    {
        public DataLandfillContext(DbContextOptions<DataLandfillContext> opt) : base(opt)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }

        public DbSet<DataItem> Images { get; set; }
    }
}