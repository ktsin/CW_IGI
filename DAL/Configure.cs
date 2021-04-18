using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class Configure
    {
        public static IServiceCollection ConfigureDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Repository.EFCore.DataContext>(
                e => { 
                    e.UseSqlite(connectionString);
                    e.EnableDetailedErrors();
                });
            return services;
        }
    }
}