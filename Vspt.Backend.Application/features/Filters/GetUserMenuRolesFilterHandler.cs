using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contract.Postgrees.ViewModels;

namespace Vspt.BackEnd.Application.features.Filters;

public sealed record GetUserMenuRolesFilterHandlerRequest : BaseRequest<uint, IReadOnlyList<GetFilterIdRequestDTO>>
{
}
internal sealed class GetUserMenuRolesFilterHandler : BaseRequestHandler<GetUserMenuRolesFilterHandlerRequest, uint, IReadOnlyList<GetFilterIdRequestDTO>>
{  
    private readonly IIdentityClaimsRepository _identityClaimsRepository;

    public GetUserMenuRolesFilterHandler(IIdentityClaimsRepository identityClaimsRepository)
    {       
        _identityClaimsRepository = identityClaimsRepository;        
    }
    protected override async Task<IReadOnlyList<GetFilterIdRequestDTO>> HandleData(uint username, CancellationToken cancellationToken)
    {
        return await _identityClaimsRepository.GetFilterClaim(username, (byte)TypeClaim.Roles, cancellationToken);       
    }
}
