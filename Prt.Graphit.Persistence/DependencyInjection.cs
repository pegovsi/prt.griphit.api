using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Prt.Graphit.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
