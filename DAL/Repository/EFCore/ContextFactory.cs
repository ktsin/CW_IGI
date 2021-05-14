using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Npgsql.NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.NodaTime;

namespace DAL.Repository.EFCore
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder
                .UseSqlite("DataSource=\"my.sqlite3\";",  b => b.MigrationsAssembly("WUI"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            // optionsBuilder.UseNpgsql(
            //     @"Host=database-1.cgmldnmavr61.eu-central-1.rds.amazonaws.com;Port=5432;"+
            //             "Database=cwdata;Username=postgres;Password=singul2040;", 
            //     o=>{
            //         o.UseNodaTime();
            //         o.MigrationsAssembly("WUI");
            //     })
            //     .EnableSensitiveDataLogging()
            //     .EnableDetailedErrors();
            // NpgsqlConnection.GlobalTypeMapper.UseNodaTime();
            return new DataContext(optionsBuilder.Options);
        }
    }
}