using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.Service.Common.Infrastructure.Repository;
using Vspt.Service.Common.Providers;
using Vspt.Service.Common.Validation.Interfaces;


namespace Vspt.Service.Common;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonInfrastructureReferences(this IServiceCollection services)
    {
        services.AddSingleton<IUniqueIdentifierProvider, UniqueIdentifierProvider>();
      

        return services;
    }

    public static IServiceCollection AddCommonProvidersReferences(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMainTimeZoneProvider, MainTimeZoneProvider>(_ =>
        {
            var mainTimeZoneId = configuration.GetValue("MainTimeZoneId", MainTimeZoneProvider.DefaultMainTimeZoneId);
            return new MainTimeZoneProvider(mainTimeZoneId);
        });

        return services;
    }
}
