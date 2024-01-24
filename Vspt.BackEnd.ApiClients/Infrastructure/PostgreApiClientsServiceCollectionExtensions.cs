using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.Box.RefitApiClient;

namespace Vspt.BackEnd.ApiClients.Infrastructure
{
    public static class PostgreApiClientsServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgreApiClients(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            return services.AddRefitApiClients(
                 ApiClientSource.FromAssemblyContaining(typeof(PostgreApiClientsServiceCollectionExtensions)),
                 configuration.GetRequiredSection("PostgreService")
             );

        }
    }
}