using System.Reflection.Metadata.Ecma335;
using Vspt.BackEnd.Application.Services.Filters.FilialsStations;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.Services.Filters.Filials
{
    public class FilterFilialsStationsService: IFilterFilialsStationsService
    {  
        private readonly IFilialsStationsDistrictsRepository _filialsStationsDistrictsRepository;
        private readonly IFilterUserFilialsService _filterUserFilialsService;

        public FilterFilialsStationsService(
             IFilialsStationsDistrictsRepository filialsStationsDistrictsRepository,
             IFilterUserFilialsService filterUserFilialsService)
        {
            _filialsStationsDistrictsRepository=filialsStationsDistrictsRepository;
            _filterUserFilialsService = filterUserFilialsService;
        }


        public async Task<IReadOnlyList<GetFilterIdResponseDTO>> GetFilialsStations(string Username, CancellationToken cancellationToken)
        {

            var existingFilials = _filterUserFilialsService.GetIdFilials(Username, cancellationToken);          

            var existValidFilals = _filialsStationsDistrictsRepository.GetFilialStation(existingFilials.Result, cancellationToken);

            return existValidFilals.Result;
        }

       
    }
}