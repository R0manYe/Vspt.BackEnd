using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Infrastructure.Repositories;


namespace Vspt.BackEnd.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureReferences(this IServiceCollection services, IConfiguration configuration)
    {

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped<IUsersRepository, UserRepository>();
      
        return services;
    }
}
