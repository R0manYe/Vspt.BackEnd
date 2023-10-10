using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Vspt.BackEnd.Application.Services.Filters.District;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Application.Services.Filters.FilialsStations;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Filters;

public sealed record GetUserFilialStationFilterHandlerRequest : BaseRequest<string, IReadOnlyList<GetFilterIdResponseDTO>>
{
}
internal sealed class GetUserFilialStationFilterHandler : BaseRequestHandler<GetUserFilialStationFilterHandlerRequest, string, IReadOnlyList<GetFilterIdResponseDTO>>
{
    private readonly IFilterFilialsStationsService _filterFilialsStationsService;

    public GetUserFilialStationFilterHandler(IFilterFilialsStationsService filterFilialsStationsService)
    {
        _filterFilialsStationsService = filterFilialsStationsService;
    }
    protected override async Task<IReadOnlyList<GetFilterIdResponseDTO>> HandleData(string username, CancellationToken cancellationToken)
    {
        return await _filterFilialsStationsService.GetFilialsStations(username,cancellationToken);
       
    }
}
