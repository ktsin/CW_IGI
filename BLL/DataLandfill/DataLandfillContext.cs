using Microsoft.EntityFrameworkCore;

namespace BLL.DataLandfill
{
    public class DataLandfillContext : DbContext
    {
        public DataLandfillContext(DbContextOptions<DataLandfillContext> opt) : base(opt)
        {
            
        }

        public DbSet<DataItem> Images { get; set; }
    }
}