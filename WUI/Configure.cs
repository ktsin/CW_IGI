using System;
using BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WUI.Auth;

namespace WUI
{
    public static class Configure
    {
        public static IServiceCollection ConfigureProjectServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureBLL(configuration
                .GetConnectionString("MainDataDebugConnectionString"));

            services.AddControllersWithViews();
            services.AddDbContext<WebUserContext>(opt =>
                opt.UseSqlite(configuration
                    .GetConnectionString("WebUserConnectionString")));

            services
                .AddIdentity<WebUser, WebUserRole>()
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

            return services;
        }
    }
}