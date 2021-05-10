using AutoMapper.Configuration;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BLL
{
    public static class Configure
    {
        // ReSharper disable once InconsistentNaming
        public static IServiceCollection ConfigureBLL(this IServiceCollection services,
            string connectionString, 
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            services.ConfigureDAL(connectionString);
            services.AddScoped<FilesService>();
            services.AddScoped<GoodsService>();
            services.AddScoped<ManagersService>();
            services.AddScoped<MessageService>();
            services.AddScoped<OrderService>();
            services.AddScoped<StoreService>();
            services.AddScoped<UserService>();
#if DEBUG
            services.AddDbContext<DataLandfill.DataLandfillContext>(opt=>
                opt.UseSqlite(config.GetConnectionString("DataLandfillConnectionStringDebug")));
#endif
#if !DEBUG
            services.AddDbContext<DataLandfill.DataLandfillContext>(opt=>
                opt.UseNpgsql(config.GetConnectionString("DataLandfillConnectionString")));
#endif
            return services;
        }
    }
}