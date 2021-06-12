using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SecretSanta.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SecretSanta.Data;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Linq;
namespace SecretSanta.Api
{
    public class Program
    {
        private static string Template { get; } = "[{Timestamp} {Level:u4}] ({Category}: {SourceContext}) {Message:lj}{NewLine}{Exception}";
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args);
           
            IConfigurationRoot config = builder.Build();
            foreach (string s in args)
            {
                if (s.Contains("DeploySampleData"))
                {
                    Console.WriteLine("variable found");
                    using (var dbcontext = new Data.DbContext())
                    {
                        dbcontext.Database.EnsureDeleted();
                        dbcontext.Database.EnsureCreated();
                        foreach (User i in DbData.Users())
                        {
                            dbcontext.Users.Add(i);
                        }
                        foreach (Group i in DbData.Groups())
                        {
                            dbcontext.Groups.Add(i);
                        }
                        foreach (GroupUser i in DbData.GroupUsers())
                        {
                            dbcontext.GroupUsers.Add(i);
                        }
                        foreach (Assignment i in DbData.Assignments())
                        {
                            dbcontext.Assignments.Add(i);
                        }foreach (Gift i in DbData.Gifts())
                        {
                            dbcontext.Gifts.Add(i);
                            //dbcontext.Gift.Add(i);
                        }
                        dbcontext.SaveChangesAsync();
                        Console.WriteLine("Data Deployed! Score!");
                    }
                }
            }
            // foreach (IConfigurationSection item in vars)
            // {
            //     if (item.Value.ToString().Equals("Deploy=true"))
            //     {
            //         Console.WriteLine("variable found");
            //         using (var dbcontext = new Data.DbContext())
            //         {
            //             dbcontext.Database.EnsureDeleted();
            //             dbcontext.Database.EnsureCreated();
            //             foreach (User i in DbData.Users())
            //             {
            //                 dbcontext.User.Add(i);
            //             }
            //             foreach (Group i in DbData.Groups())
            //             {
            //                 dbcontext.Group.Add(i);
            //             }
            //             dbcontext.SaveChangesAsync();
            //             Console.WriteLine("Data Deployed! Score!");
            //         }
            //     }
            // }

            var host = CreateHostBuilder(args).Build();
         
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SecretSanta.Data.DbContext>();
                db.Database.Migrate();

            }
            

            host.Run();
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
           
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               })
               .UseSerilog((context, services, configuration) => configuration
                    
                    .WriteTo.Console(
                        
                        theme: AnsiConsoleTheme.Code)
                    .WriteTo.File(
                        context.Configuration.GetConnectionString("LogConnection"),
                        restrictedToMinimumLevel: LogEventLevel.Information
                        )
                );
               
           
    }
}
