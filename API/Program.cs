using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Program
    {
        //Program.cs file is the entry point to our application, when we execute dotnet run, then it's going
        //to strat looking for this main method in this file
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
