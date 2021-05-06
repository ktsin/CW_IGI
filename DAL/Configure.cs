using DAL.Repository.EFCore.Repositories;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class Configure
    {
        // ReSharper disable once InconsistentNaming
        public static IServiceCollection ConfigureDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Repository.EFCore.DataContext>(
                e => { 
                    e.UseSqlite(connectionString);
                    e.EnableDetailedErrors();
                    e.EnableSensitiveDataLogging();
                });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGoodRepository, GoodRepository>();
            services.AddScoped<IManagersRepository, ManagersRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBasketRepository, UserBasketRepository>();
            
            return services;
        }
    }
}