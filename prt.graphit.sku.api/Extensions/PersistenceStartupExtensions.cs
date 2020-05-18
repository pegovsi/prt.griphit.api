using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Persistence;

namespace Prt.Graphit.Api.Extensions
{
    public static class PersistenceStartupExtensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SkuDbContext>(options =>
                options.UseNpgsql(configuration.GetSection("ConnectionStrings:Database").Value));

            services.AddScoped<ISkuDbContext>(provider => provider.GetService<SkuDbContext>());

            services.AddPersistence();
            return services;
        }
    }
}
