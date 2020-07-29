using System.Collections.Generic;
using Autofac.Extensions.DependencyInjection;
using GodelTech.Microservices.Core.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GodelTech.ReadMe.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())

                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.AddInMemoryCollectionFromEnvVariables(new Dictionary<string, string>
                    {
                        ["DB_CONNECTION_STRING"] = "ConnectionStrings:Default"
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
