using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using Vspt.Box.Security;

namespace Vspt.Box.RefitApiClient;

public static class RefitApiClientServiceCollectionExtensions
{
	public static IServiceCollection AddRefitApiClients(
		this IServiceCollection services,
		ApiClientSource source,
		IConfiguration configuration
	)
	{
		return services.AddRefitApiClients<ApiClientSettings>(source, configuration);
	}

	public static IServiceCollection AddRefitApiClients<TApiClientSettings>(
		this IServiceCollection services,
		ApiClientSource source,
		IConfiguration configuration
	)
		where TApiClientSettings : ApiClientSettings
	{
		var settings = configuration.Get<TApiClientSettings>();
		ArgumentNullException.ThrowIfNull(settings);

		return services.AddRefitApiClients(source, settings);
	}

	public static IServiceCollection AddRefitApiClients<TApiClientSettings>(
		this IServiceCollection services,
		ApiClientSource source,
		TApiClientSettings settings
	)
		where TApiClientSettings : ApiClientSettings
	{
		if (typeof(TApiClientSettings) != typeof(ApiClientSettings))
		{
			services.AddSingleton(settings);
		}

		return services.AddRefitApiClients(source.GetApiClients(), settings);
	}

	public static IServiceCollection AddRefitApiClients(
		this IServiceCollection services,
		IEnumerable<Type> aplClientTypes,
		ApiClientSettings settings
	)
	{
		foreach (var apiClientType in aplClientTypes)
		{
			services.AddRefitApiClient(apiClientType, settings);
		}

		return services;
	}

	public static IServiceCollection AddRefitApiClient<TApiClient>(
		this IServiceCollection services,
		ApiClientSettings settings
	)
		where TApiClient : class
	{
		return services.AddRefitApiClient(typeof(TApiClient), settings);
	}

	public static IServiceCollection AddRefitApiClient(
		this IServiceCollection services,
		Type apiClientType,
		ApiClientSettings settings
	)
	{
		var httpClientBuilder = services.AddRefitClient(apiClientType, serviceProvider =>
		{
			var refitSettings = new RefitSettings
			{
				ExceptionFactory = ApiClientExceptionFactory.MakeException,
				ContentSerializer = new DefaultHttpContentSerializer(),
				InjectMethodInfoAsProperty = true,
			};
			return refitSettings;
		});

		ArgumentNullException.ThrowIfNull(settings.Url);

		httpClientBuilder.ConfigureHttpClient(c =>
		{
			c.BaseAddress = settings.Url;
			if (!string.IsNullOrEmpty(settings.ApiKey))
			{
				c.DefaultRequestHeaders.Add(SupportedHeaderNames.ApiKeyHeaderName, settings.ApiKey);
			}
		});

		if (settings.SendCurrentUser)
		{
			services.TryAddScoped<RefitHttpMessageHandler>();
			httpClientBuilder.AddHttpMessageHandler<RefitHttpMessageHandler>();
		}

		return services;
	}
}
