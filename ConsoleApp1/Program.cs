using WorkingConsoleDB.DataAccess;
using WorkingConsoleDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Serilog;

namespace WorkingConsoleDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                IConfigurationBuilder builder = new ConfigurationBuilder();
                BuildConfig(builder);
                //instantiating logging service
                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Build()).Enrich.FromLogContext().CreateLogger();
                Log.Logger.Information("Application Starting");

                var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
                {               
                }).UseSerilog().Build();

                var contextOptions = new DbContextOptionsBuilder<PeopleContext>().UseSqlServer(builder.Build().GetConnectionString("Default")).Options;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<PeopleContext>(options =>
                    {
                        //options.UseSqlServer(builder.Build().GetConnectionString("Default"));
                        options.UseSqlServer("Data Source=.\\MYSQLSERVER;Initial Catalog=DemoMe;Integrated Security=True;");

                    });
                });
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
