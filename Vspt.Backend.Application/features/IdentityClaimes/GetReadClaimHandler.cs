using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityClaimes;

public sealed record GetReadClaimRequest : BaseRequest<Unit, IReadOnlyList<IdentityClaims>>
{
}
internal sealed class GetReadClaimHandler : BaseRequestHandler<GetReadClaimRequest, Unit, IReadOnlyList<IdentityClaims>>
{
    private readonly IIdentityClaimsRepository _claimsRepository;
   


    public GetReadClaimHandler( IIdentityClaimsRepository claimsRepository)
    {
        _claimsRepository = claimsRepository;       
    }

    protected override async Task<IReadOnlyList<IdentityClaims>> HandleData(Unit unit, CancellationToken cancellationToken)
    {           
       return await _claimsRepository.GetReadClaims( cancellationToken); 
    }
}
