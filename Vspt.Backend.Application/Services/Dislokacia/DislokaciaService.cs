using Vspt.BackEnd.Application.Services.Filters.FilialsStations;
using Vspt.BackEnd.Flagman.ApiClients;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Application.Services.SprOrg
{
    internal sealed class DislokaciaService : IDislokaciaService
    {
        private readonly IFlagmanDislokaciaApiClient _flagmanDislokaciaApiClient;
        private readonly IFilterFilialsStationsService _filterFilialsStationsService;
        public DislokaciaService(IFlagmanDislokaciaApiClient flagmanDislokaciaApiClient, IFilterFilialsStationsService filterFilialsStationsService)
        {
            _flagmanDislokaciaApiClient = flagmanDislokaciaApiClient;
            _filterFilialsStationsService = filterFilialsStationsService;   
        }       

        public async Task<IReadOnlyList<GetAllDislokacia>> GetDislokacia(CancellationToken cancellationToken)
        {
            return await _flagmanDislokaciaApiClient.GetDislokacia();
        }

        public async Task<IReadOnlyList<GetAllDislokacia>> GetDislokaciaFilterStations(uint userId,CancellationToken cancellationToken)
        {
            var exiistingStation=_filterFilialsStationsService.GetFilialsStationsId(userId,cancellationToken).Result;

           return await _flagmanDislokaciaApiClient.GetDislokaciaFiltrStation(exiistingStation,cancellationToken); 
        }      
    }
}
