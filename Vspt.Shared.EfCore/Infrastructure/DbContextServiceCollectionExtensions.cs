using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Vspt.Box.AbstractTransactions;

namespace Vspt.Box.EfCore.Infrastructure;

public static class DbContextServiceCollectionExtensions
{
	public static IServiceCollection AddDefaultDbContext<TDbContext>(
		this IServiceCollection services,
		Action<IServiceProvider, DbContextOptionsBuilder> optionsAction
	)
		where TDbContext : DbContext
	{
		services.AddDbContextFactory<TDbContext>((serviceProvider, options) =>
		{
			options.ReplaceService<IMigrator, TransactionalMigrator>();
			optionsAction(serviceProvider, options);
		});

		services.RemoveAll<TDbContext>();

		services.AddScoped(serviceProvider =>
		{
			var factory = serviceProvider.GetRequiredService<IDbContextFactory<TDbContext>>();
			var dbContext = factory.CreateDbContext();
			return dbContext;
		});

		services.AddScoped<ReadOnlyDbContext<TDbContext>>();

		services.AddScoped<DbContextAbstractTransactionManager<TDbContext>>();

		services.AddScoped<IAbstractTransactionManager>(x => x.GetRequiredService<DbContextAbstractTransactionManager<TDbContext>>());

		return services;
	}
}
