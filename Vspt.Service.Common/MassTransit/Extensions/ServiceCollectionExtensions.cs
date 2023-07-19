using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Vspt.Service.Common.MassTransit.Configuration;

namespace Vspt.Service.Common.MassTransit.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddMassTransitRabbitMq(
		this IServiceCollection services,
		RabbitMqConfiguration configuration)
	{
		return AddMassTransitRabbitMq(services, configuration, null);
	}

	public static IServiceCollection AddMassTransitRabbitMq(
		this IServiceCollection services,
		RabbitMqConfiguration configuration,
		Action<IBusRegistrationConfigurator> massTransitOptions)
	{
		return AddMassTransitRabbitMq(services, configuration, massTransitOptions, null);
	}

	public static IServiceCollection AddMassTransitRabbitMq(
		this IServiceCollection services,
		RabbitMqConfiguration configuration,
		Action<IBusRegistrationConfigurator> massTransitOptions,
		Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> rabbitOptions)
	{
		services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

		services.AddMassTransit(massTransitConfig =>
		{
			massTransitOptions?.Invoke(massTransitConfig);

			massTransitConfig.UsingRabbitMq((context, rabbitConfig) =>
			{
				rabbitConfig.Host(configuration.HostAddress, h =>
				{
					h.Username(configuration.Username);
					h.Password(configuration.Password);
				});

				rabbitOptions?.Invoke(context, rabbitConfig);

				var nameFormatter = string.IsNullOrEmpty(configuration.QueuePrefix)
					? new KebabCaseEndpointNameFormatter(false)
					: new KebabCaseEndpointNameFormatter($"{configuration.QueuePrefix}-", false);
				rabbitConfig.ConfigureEndpoints(context, nameFormatter);
			});
		});

		return services;
	}
}
