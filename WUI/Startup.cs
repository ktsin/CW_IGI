using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WUI.Auth;
using BLL;

namespace WUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureProjectServices(Configuration);
//             services.ConfigureBLL(Configuration
//                 .GetConnectionString("MainDataDebugConnectionString"));
//             
//             services.AddControllersWithViews();
//             services.AddDbContext<WebUserContext>(opt =>
//                 opt.UseSqlite(Configuration
//                     .GetConnectionString("WebUserConnectionString")));
//
//             services
//                 .AddIdentity<WebUser, WebUserRole>()
//                 .AddEntityFrameworkStores<WebUserContext>();
//             services.Configure<IdentityOptions>(opt =>
//             {
// #if !DEBUG
//                 // Password settings.
//                 opt.Password.RequireDigit = true;
//                 opt.Password.RequireLowercase = true;
//                 opt.Password.RequireNonAlphanumeric = true;
//                 opt.Password.RequireUppercase = true;
//                 opt.Password.RequiredLength = 6;
//                 opt.Password.RequiredUniqueChars = 1;
// #endif
// #if DEBUG
//                 // Password settings.
//                 opt.Password.RequireDigit = true;
//                 opt.Password.RequireLowercase = false;
//                 opt.Password.RequireNonAlphanumeric = false;
//                 opt.Password.RequireUppercase = false;
//                 opt.Password.RequiredLength = 1;
//                 opt.Password.RequiredUniqueChars = 0;
// #endif
//                 // Lockout settings.
//                 opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//                 opt.Lockout.MaxFailedAccessAttempts = 5;
//                 opt.Lockout.AllowedForNewUsers = true;
//
//                 // User settings.
//                 opt.User.AllowedUserNameCharacters =
//                     "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
//                 opt.User.RequireUniqueEmail = false;
//             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}