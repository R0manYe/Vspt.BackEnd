using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.Entity;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.BackEnd.Infrastructure.Repositories;
using Vspt.Box.EfCore.Infrastructure;
using Vspt.Box.EfCore.Npgsql.Infrastructure;
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
      
        return services;
    }
}    