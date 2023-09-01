using Grotem.Box;
using Grotem.Box.Notification.Sdk.Configuration;
using Grotem.Box.Notification.Sdk.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vspt.BackEnd.Flagman.ApiClients.Infrastructure;
using Vspt.Common.Identity.Infrastructure;


namespace Vspt.BackEnd.Application.Extensions;

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
