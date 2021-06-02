using System;
using System.Security;
using BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WUI.Auth;
using Npgsql.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Builder;

namespace WUI
{
    using AutoMapper;
    using Microsoft.Extensions.Localization;

    public static class Configure
    {
        public static IServiceCollection ConfigureProjectServices(this IServiceCollection services,
            IConfiguration configuration)
        {
#if DEBUG
            var main_data = "MainDataDebugConnectionStringDebug";
            var web_user = "WebUserConnectionStringDebug";
            services.AddDbContext<WebUserContext>(opt =>
                opt.UseSqlite(configuration
                    .GetConnectionString(web_user)));
#endif
#if !DEBUG
            var main_data = "MainDataDebugConnectionString";
            var web_user = "WebUserConnectionString";
            services.AddDbContext<WebUserContext>(opt =>
                opt.UseNpgsql(configuration
                    .GetConnectionString(web_user)));
#endif

            services.ConfigureBLL(configuration
                .GetConnectionString(main_data), configuration);
            services.AddAutoMapper(BLL.Configure.ConfigureMapper);

            services
                .AddIdentity<WebUser, IdentityRole>()
                .AddEntityFrameworkStores<WebUserContext>();
            services.Configure<IdentityOptions>(opt =>
            {
#if !DEBUG
                // Password settings.
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequiredUniqueChars = 1;
#endif
#if DEBUG
                // Password settings.
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequiredUniqueChars = 0;
#endif
                // Lockout settings.
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.AllowedForNewUsers = true;

                // User settings.
                opt.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
                opt.User.RequireUniqueEmail = false;
            });

            
            services.AddControllersWithViews()
                .AddViewLocalization();
            services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
            services.AddRazorPages();

            return services;
        }
    }
}