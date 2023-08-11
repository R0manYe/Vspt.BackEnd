using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.Box.RefitApiClient;

namespace Vspt.BackEnd.Flagman.ApiClient.Infrastructure;

public static class FlagmanApiClientsServiceCollectionExtensions
{
    public static IServiceCollection AddCatalogApiClients(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services.AddRefitApiClients(
            ApiClientSource.FromAssemblyContaining(typeof(FlagmanApiClientsServiceCollectionExtensions)),
            configuration.GetSection("FlagmanService")
        );
    }
}
