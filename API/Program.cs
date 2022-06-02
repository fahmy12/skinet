using System;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        //Program.cs file is the entry point to our application, when we execute dotnet run, then it's going
        //to strat looking for this main method in this file
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //@ 28 -> 2:10
                //we can log any information out into our console, will create an instance of a loggerFactory
                //and a loggerFactory allows us to create instances of a logger class
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    //@ 28 -> 4:08
                    //And what this MigrageAsync commands does this is going to apply any pending migrations
                    //for a context to the database and it will create the database if it does not already exist
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }          
            }
            host.Run();
        }
        //CreateHostBuilder does a few things to configure our application, it's going to apply some deault settings
        //to our application, things like setting the ContentRoutePath of our application to System.IO.Directory.GetCurrentDirectory()
        //and it's also going to load the cofiguration from any configuration files
        //also it is loads configuration files into memory
        //and we've got a couple of configuration files provided for us: appsettings.json and appsettings.Development.json
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //then it's call to use Startup class
                    webBuilder.UseStartup<Startup>();
                });
    }
}
