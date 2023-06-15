using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Vspt.Box.EfCore;

public static class DbSetExtensions
{
	public static DbContext GetDbContext<TEntity>(this DbSet<TEntity> dbSet)
		where TEntity : class
	{
		IInfrastructure<IServiceProvider> infrastructure = dbSet;
		var serviceProvider = infrastructure.Instance;
		var currentDbContext = serviceProvider.GetRequiredService<ICurrentDbContext>();
		return currentDbContext.Context;
	}
}
