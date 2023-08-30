using Grotem.Box.Application.Extensions;
using Vspt.BackEnd.Flagman.ApiClient.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.Common.Identity.Infrastructure;
using Grotem.Box.Notification.Sdk.Configuration;
using Grotem.Box.Notification.Sdk.Extensions;

namespace Vspt.BFF.B2BWeb.Application.Extensions;

public static class ApiClientsServiceCollectionExtensions
{
	public static IServiceCollection AddApiClientReferences(this IServiceCollection services, IConfiguration configuration)
	{
		var webApiClientConfigurations = configuration.GetRequiredSection("WebApiClients");

		#region Sorted
		services.AddFlagmanApiClients(webApiClientConfigurations);
		
		#endregion

		services.AddIdentityApiClients(configuration.GetRequiredSection("WebApiClientIdentityService"));

		var notificationHttpConfiguration = configuration.GetRequiredSectionValue<NotificationHttpConfiguration>("WebApiClientNotificationService");
		services.RegisterHttpNotificationManager(notificationHttpConfiguration);

		return services;
	}
}
