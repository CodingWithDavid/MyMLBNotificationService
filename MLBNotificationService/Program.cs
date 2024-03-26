using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

//3rd party
using Serilog;


//DI, Logging, Settings
namespace MLBNotificationService.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our configuration
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            //set up logging
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            //setup our HOST
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    //Control Service
                    services.AddTransient<IControlService, ControlService>();
                })
                .UseSerilog()
                .Build();

            //run our Control service
            var svc = ActivatorUtilities.CreateInstance<ControlService>(host.Services);
            _ = svc.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
