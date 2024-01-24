using MediatR;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Application.Services.Filters.FilialsStations;
using Vspt.BackEnd.Application.Services.SprOrg;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Flagman.ApiClients;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Sources;

public sealed record GetReadOrgRequest : BaseRequest<uint, IReadOnlyList<Spr_org>>
{
}
internal sealed class GetReadOrgHandler : BaseRequestHandler<GetReadOrgRequest, uint, IReadOnlyList<Spr_org>>
{
    private readonly IFilterFilialsStationsService _filterFilialsStationsService;
    private readonly ISprOrgService _sprOrgService;

    public GetReadOrgHandler(IFilterFilialsStationsService filterFilialsStationsService, ISprOrgService sprOrgService)
    {
        _filterFilialsStationsService = filterFilialsStationsService;
        _sprOrgService = sprOrgService;
    }

    protected override async Task<IReadOnlyList<Spr_org>> HandleData(uint userId, CancellationToken cancellationToken)
    {
        var exitingFilials = _filterFilialsStationsService.GetFilialsStationsId(userId, cancellationToken).Result;
        var result= await _sprOrgService.GetSprOrgResult(exitingFilials, cancellationToken);
        return result;
    }
}
