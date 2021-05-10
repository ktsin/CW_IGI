using AutoMapper;
using AutoMapper.Configuration;
using BLL.DTO;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DAL.Entities;
using UserBasket = DAL.Entities.UserBasket;


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
            services.AddDbContext<DataLandfill.DataLandfillContext>(opt =>
                opt.UseNpgsql(config.GetConnectionString("DataLandfillConnectionString")));
#endif
            return services;
        }

        public static void ConfigureMapper(IMapperConfigurationExpression e)
        {
            e.CreateMap<Category, CategoryDTO>();
            e.CreateMap<Good, GoodDTO>();
            e.CreateMap<Managers, ManagersDTO>();
            e.CreateMap<Message, MessageDTO>();
            e.CreateMap<Order, OrderDTO>();
            e.CreateMap<Store, StoreDTO>();
            e.CreateMap<UserBasket, DTO.UserBasket>();
            e.CreateMap<User, UserDTO>();

            e.CreateMap<CategoryDTO, Category>();
            e.CreateMap<GoodDTO, Good>();
            e.CreateMap<ManagersDTO, Managers>();
            e.CreateMap<MessageDTO, Message>();
            e.CreateMap<OrderDTO, Order>();
            e.CreateMap<StoreDTO, Store>();
            e.CreateMap<DTO.UserBasket, UserBasket>();
            e.CreateMap<UserDTO, User>();
        }
    }
}