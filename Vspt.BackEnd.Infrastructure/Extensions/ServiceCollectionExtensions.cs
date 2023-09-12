using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Infrastructure.Repositories;
using Vspt.Service.Common;


namespace Vspt.BackEnd.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
   public static IServiceCollection AddInfrastructureReferences(this IServiceCollection services, IConfiguration configuration)
    {
  
      
        services.AddCommonInfrastructureReferences();
        services.AddCommonProvidersReferences(configuration);
       
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IClaimsRepository, ClaimRepository>();
        services.AddScoped<IRolesRepository, RoleRepository>();     
     

        return services;
    }
}    