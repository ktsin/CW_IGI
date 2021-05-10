using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Npgsql;

namespace WUI.Auth
{
    public class ContextFactory : IDesignTimeDbContextFactory<WebUserContext>
    {
        public WebUserContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebUserContext>();
#if DEBUG
            optionsBuilder.UseSqlite("DataSource=\"/home/ktsin/RiderProjects/cw/users.sqlite3;\"")
                .EnableDetailedErrors();
#endif
#if !DEBUG
            optionsBuilder.UseNpgsql(
                    @"Host=database-1.cgmldnmavr61.eu-central-1.rds.amazonaws.com;Port=5432;" +
                    "Database=cwusers;Username=postgres;Password=singul2040;",
                    o => o.UseNodaTime())
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            NpgsqlConnection.GlobalTypeMapper.UseNodaTime();
#endif
            return new WebUserContext(optionsBuilder.Options);
        }
    }
}