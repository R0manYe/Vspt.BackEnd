using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.Box.RefitApiClient;
using Vspt.Common.Identity.ApiClients;
using Vspt.Common.Identity.MockApiClients;

namespace Vspt.Common.Identity.Infrastructure;

public static class IdentityApiClientsServiceCollectionExtension
{
	public static IServiceCollection AddIdentityApiClients(
		this IServiceCollection services,
		IConfiguration configuration
	)
	{
		var settings = configuration.Get<IdentityApiClientSettings>();
		if (settings.UseMocks)
		{
			AddMockApiClients(services, settings);
		}
		else
		{
			services.AddRefitApiClients(
				ApiClientSource.FromSiblingsOfType(typeof(IIdentityUserApiClient)),
				settings
			);
		}

		return services;
	}

	private static void AddMockApiClients(IServiceCollection services, IdentityApiClientSettings settings)
	{
		var type = typeof(MockIdentityUserApiClient);
		var ns = type.Namespace;

		// Types with same namespace and not compiler-generated
		var implementationTypes = type.Assembly.DefinedTypes.Where(type => type.Namespace == ns && !type.IsNested);
		foreach (var implementationType in implementationTypes)
		{
			var interfaceType = implementationType.GetInterfaces()[0];
			services.AddSingleton(interfaceType, implementationType);
		}
	}
}
