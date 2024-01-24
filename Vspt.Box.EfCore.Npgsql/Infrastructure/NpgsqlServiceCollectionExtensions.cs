using System;
using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Vspt.Box.EfCore.Npgsql.Infrastructure;

public static class NpgsqlServiceCollectionExtensions
{
    // Only useful parts from https://github.com/npgsql/npgsql/blob/v7.0.1/src/Npgsql.DependencyInjection/NpgsqlServiceCollectionExtensions.cs#L32
    public static IServiceCollection AddNpgsqlDbDataSource(
        this IServiceCollection services,
        Action<NpgsqlDataSourceBuilder> dataSourceBuilderAction
    )
    {
        services.AddSingleton(serviceProvider =>
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder();
            dataSourceBuilder.UseLoggerFactory(serviceProvider.GetService<ILoggerFactory>());
            dataSourceBuilderAction(dataSourceBuilder);
            return dataSourceBuilder.Build();
        });

        services.AddSingleton<DbDataSource>(serviceProvider =>
        {
            return serviceProvider.GetRequiredService<NpgsqlDataSource>();
        });

        return services;
    }
}
