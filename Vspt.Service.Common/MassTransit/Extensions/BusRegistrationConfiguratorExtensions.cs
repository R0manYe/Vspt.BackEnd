using System;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Vspt.Service.Common.MassTransit.Extensions;
public static class BusRegistrationConfiguratorExtensions
{
	public static void UseEntityFrameworkOutbox<TDbContext>(this IBusRegistrationConfigurator options)
		where TDbContext : DbContext
	{
		options.AddEntityFrameworkOutbox<TDbContext>(outboxConfig =>
		{
			outboxConfig.QueryDelay = TimeSpan.FromSeconds(1);
			outboxConfig.UsePostgres();
			outboxConfig.UseBusOutbox();
		});
	}
}
