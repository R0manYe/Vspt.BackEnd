using Vspt.BackEnd.Application.Services.Filters.FilialsStations;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Filters;

public sealed record GetUserFilialStationFilterHandlerRequest : BaseRequest<string, IReadOnlyList<GetFilterIdRequestDTO>>
{
}
internal sealed class GetUserFilialStationFilterHandler : BaseRequestHandler<GetUserFilialStationFilterHandlerRequest, string, IReadOnlyList<GetFilterIdRequestDTO>>
{
    private readonly IFilterFilialsStationsService _filterFilialsStationsService;

    public GetUserFilialStationFilterHandler(IFilterFilialsStationsService filterFilialsStationsService)
    {
        _filterFilialsStationsService = filterFilialsStationsService;
    }
    protected override async Task<IReadOnlyList<GetFilterIdRequestDTO>> HandleData(string username, CancellationToken cancellationToken)
    {
        return await _filterFilialsStationsService.GetFilialsStationsId(username,cancellationToken);
       
    }
}
