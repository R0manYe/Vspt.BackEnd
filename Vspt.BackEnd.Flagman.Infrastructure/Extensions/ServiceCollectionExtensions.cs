using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.BackEnd.Flagman.ApiClient.Infrastructure;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Infrastructure.Repositories;



namespace Vspt.BackEnd.Flagman.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureFlagmanReferences(this IServiceCollection services, IConfiguration configuration)
    {

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped<IDislokaciaRepository, DislokaciaRepository>();
        services.AddScoped<IVsptSubjectPersoneRepository, VsptSubjectPersoneRepository>();
        var webApiClientConfigurations = configuration.GetRequiredSection("WebApiClients");

        
        services.AddFlagmanApiClients(webApiClientConfigurations);
        return services;
    }
}
