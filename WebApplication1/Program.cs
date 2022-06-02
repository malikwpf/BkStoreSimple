using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var WebHost = CreateHostBuilder(args).Build();
            RunMigrations(WebHost);
            WebHost.Run();
        }

        private static void RunMigrations(IHost webHost)
        {
            using(var scope = webHost.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BookStoreDb>();
                db.Database.Migrate();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                   
                });
    }
}
