using Microsoft.Extensions.DependencyInjection;
using DAL;

namespace BLL
{
    public static class Configure
    {
        public static IServiceCollection ConfigureBLL(this IServiceCollection services, string connectionString)
        {
            services.ConfigureDAL(connectionString);
            return services;
        }
    }
}