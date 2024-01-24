using Vspt.BackEnd.Application.Services.Filters.FilialsStations;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contract.Postgrees.ViewModels;

namespace Vspt.BackEnd.Application.features.Filters;

public sealed record GetUserFilialStationFilterHandlerRequest : BaseRequest<uint, IReadOnlyList<GetFilterIdRequestDTO>>
{
}
internal sealed class GetUserFilialStationFilterHandler : BaseRequestHandler<GetUserFilialStationFilterHandlerRequest, uint, IReadOnlyList<GetFilterIdRequestDTO>>
{

    private readonly IIdentityClaimsRepository _identityClaimsRepository;

    public GetUserFilialStationFilterHandler(IIdentityClaimsRepository identityClaimsRepository)
    {
        _identityClaimsRepository = identityClaimsRepository;
    }
    protected override async Task<IReadOnlyList<GetFilterIdRequestDTO>> HandleData(uint username, CancellationToken cancellationToken)
    {
        return await _identityClaimsRepository.GetFilterClaim(username, (byte)TypeClaim.Roles, cancellationToken);

    }
}
