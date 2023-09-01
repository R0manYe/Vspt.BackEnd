using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tiss.Pricing.PublicModels;
using Vspt.Box.RefitApiClient;


namespace Vspt.BackEnd.Flagman.ApiClients.Infrastructure;

public static class FlagmanApiClientsServiceCollectionExtensions
{
    public static IServiceCollection AddFlagmanApiClients(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services.AddRefitApiClients<FlagmanApiClientSettings>(
            ApiClientSource.FromAssemblyContaining(typeof(FlagmanApiClientsServiceCollectionExtensions)),
            configuration.GetRequiredSection("FlagmanService")
        );
    }
}
