using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastre.Core.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cadastre.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build(); //создание хоста
            using (var scope = host.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var ctx = provider.GetService<AppDBContext>())
                {
                    ctx.Database.Migrate();//миграция БД. Приведение БД к последней версии. Если БД нет, то она создается.
                }
            }
            host.Run(); //Запуск хоста.
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
