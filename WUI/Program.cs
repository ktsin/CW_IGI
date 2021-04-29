using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace WUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var l = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                l.Info("App started!");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                l.Fatal($"Fatal error: {ex.Message};\n internal: {ex.InnerException?.Message}");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .UseNLog(NLogAspNetCoreOptions.Default);
    }
}