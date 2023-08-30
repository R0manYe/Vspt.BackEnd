using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Vspt.BFF.B2BWeb.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplicationReferences(this IServiceCollection services, IConfiguration configuration)
	{
		
		//services.AddScoped<IAdditionalPricesService, AdditionalPricesService>();
	

		return services;
	}
}
