using WorkingConsoleDB.DataAccess;
using WorkingConsoleDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WorkingConsoleDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("sup 1");
                //  CreateHostBuilder(args).Build().Run();
                Console.WriteLine("sup 2");
                var contextOptions = new DbContextOptionsBuilder<PeopleContext>().UseSqlServer("Data Source=.\\SQL2017;Initial Catalog=DemoMe;Integrated Security=True;").Options;

                //   using var context = new ApplicationDbContext(contextOptions);
                PeopleContext db = new PeopleContext(contextOptions);
                db.People.Add(new Person());
                db.SaveChanges();
                Console.WriteLine("sup 3");
            }
            catch(Exception ex)
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
                        options.UseSqlServer("Data Source=.\\SQL2017;Initial Catalog=DemoMe;Integrated Security=True;");

                    });
                });
    }
}
