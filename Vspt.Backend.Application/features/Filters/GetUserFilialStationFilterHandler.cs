using Vspt.BackEnd.Application.Services.Filters.FilialsStations;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Filters;

public sealed record GetUserFilialStationFilterHandlerRequest : BaseRequest<uint, IReadOnlyList<GetFilterIdRequestDTO>>
{
}
internal sealed class GetUserFilialStationFilterHandler : BaseRequestHandler<GetUserFilialStationFilterHandlerRequest, uint, IReadOnlyList<GetFilterIdRequestDTO>>
{
    private readonly IFilterFilialsStationsService _filterFilialsStationsService;

    public GetUserFilialStationFilterHandler(IFilterFilialsStationsService filterFilialsStationsService)
    {
        _filterFilialsStationsService = filterFilialsStationsService;
    }
    protected override async Task<IReadOnlyList<GetFilterIdRequestDTO>> HandleData(uint username, CancellationToken cancellationToken)
    {
        return await _filterFilialsStationsService.GetFilialsStationsId(username,cancellationToken);
       
    }
}
