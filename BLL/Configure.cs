using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using DAL;

namespace BLL
{
    public static class Configure
    {
        // ReSharper disable once InconsistentNaming
        public static IServiceCollection ConfigureBLL(this IServiceCollection services, string connectionString)
        {
            services.ConfigureDAL(connectionString);
            services.AddScoped<FilesService>();
            services.AddScoped<GoodsService>();
            services.AddScoped<ManagersService>();
            services.AddScoped<MessageService>();
            services.AddScoped<OrderService>();
            services.AddScoped<StoreService>();
            services.AddScoped<UserService>();

            return services;
        }
    }
}