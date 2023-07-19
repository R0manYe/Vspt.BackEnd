using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vspt.BackEnd.Flagman.Domain.Contract;


namespace Vspt.BackEnd.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationFlagmanReferences(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

      
        return services;
    }
}
