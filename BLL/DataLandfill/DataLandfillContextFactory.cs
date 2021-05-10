using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql;

namespace BLL.DataLandfill
{
    public class DataLandfillContextFactory : IDesignTimeDbContextFactory<DataLandfillContext>
    {
        public DataLandfillContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataLandfillContext>();
#if DEBUG
            optionsBuilder.UseSqlite("DataSource=\"/home/ktsin/RiderProjects/cw/landfill.sqlite3\";")
                .EnableDetailedErrors();
#endif
#if !DEBUG
            optionsBuilder.UseNpgsql(
                @"Host=database-1.cgmldnmavr61.eu-central-1.rds.amazonaws.com;Port=5432;" +
                "Database=cwdata_landfill;Username=postgres;Password=singul2040;",
                o => o.UseNodaTime());
            NpgsqlConnection.GlobalTypeMapper.UseNodaTime();
#endif
            return new DataLandfillContext(optionsBuilder.Options);
        }
    }
}