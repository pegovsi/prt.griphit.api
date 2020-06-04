using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Prt.Graphit.Application.System.Commands.SeedSampleData;
using Prt.Graphit.Persistence;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.Migrate();

                    var mediator = services.GetRequiredService<IMediator>();
                    await mediator.Send(new SeedSampleDataCommand(), CancellationToken.None);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;

                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true);

                        if (env.IsDevelopment())
                        {
                            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                            if (appAssembly != null)
                            {
                                config.AddUserSecrets(appAssembly, optional: true);
                            }
                        }

                        config.AddEnvironmentVariables();
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
