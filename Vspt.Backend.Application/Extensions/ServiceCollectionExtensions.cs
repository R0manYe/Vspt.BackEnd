using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Reflection;
using Vspt.BackEnd.Application.Services.Filters.District;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Application.Services.Filters.FilialsStations;
using Vspt.BackEnd.Application.Services.SprOrg;
using Vspt.BackEnd.Application.Services.SubjectPersone;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Flagman.ApiClients;
using Vspt.BackEnd.Infrastructure.Repositories;

namespace Vspt.BackEnd.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationReferences(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());      
        services.AddScoped<ISubjectPersoneService, SubjectPersoneService>();
        services.AddScoped<ISprOrgService,SprOrgService>();
        services.AddScoped<ISprDistrictsRepository, SprDistrictRepository>();
        services.AddScoped<ISprFilialsRepository, SprFilialRepository>();
        services.AddScoped<IFilialsStationsDistrictsRepository, FilialsStationsDistrictsRepository>();
        services.AddScoped<IFilterUserFilialsService, FilterUserFilialsService>();
        services.AddScoped<IFilterUserDistrictsService, FilterUserDistrictsService>();
        services.AddScoped<IFilterFilialsStationsService, FilterFilialsStationsService>();
        services.AddScoped<IDislokaciaService, DislokaciaService>();
        services.AddScoped<ISprCargoService,SprCargoService>();
        services.AddScoped<ISprSvodRepository, SprSvodRepository>();
        services.AddScoped<IDailyReportingPlanDetailsRepository, DailyReportingPlanDetailsRepository>();

        services.AddRefitClient<IFlagmanApiClient>().ConfigureHttpClient(c=>c.BaseAddress=new Uri("https://localhost:7201"));
        services.AddRefitClient<IFlagmanSprOrgApiClient>().ConfigureHttpClient(c=>c.BaseAddress=new Uri("https://localhost:7201"));
        services.AddRefitClient<IFlagmanDislokaciaApiClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7201"));

        return services;
    }
}
