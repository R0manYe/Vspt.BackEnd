using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Reflection;
using Vspt.BackEnd.Application.Services.SubjectPersone;
using Vspt.BackEnd.Flagman.ApiClient.Infrastructure;
using Vspt.Pricing.ApiClients;

namespace Vspt.BackEnd.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationReferences(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        var webApiClientConfigurations = configuration.GetRequiredSection("WebApiClients");
        services.AddFlagmanApiClients(webApiClientConfigurations);
        services.AddScoped<ISubjectPersoneService, SubjectPersoneService>();
        services.AddRefitClient<IFlagmanApiClient>().ConfigureHttpClient(c=>c.BaseAddress=new Uri("https://localhost:7201"));

        return services;
    }
}
