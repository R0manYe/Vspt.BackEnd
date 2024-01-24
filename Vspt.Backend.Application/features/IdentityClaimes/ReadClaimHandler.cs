using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes;

public sealed record ReadClaimRequest : BaseRequest<Unit, IReadOnlyList<GetIdentityClaimResponseDTO>>
{
}
internal sealed class ReadClaimHandler : BaseRequestHandler<ReadClaimRequest, Unit, IReadOnlyList<GetIdentityClaimResponseDTO>>
{
    private readonly IIdentityClaimsRepository _claimsRepository;
   


    public ReadClaimHandler( IIdentityClaimsRepository claimsRepository)
    {
        _claimsRepository = claimsRepository;       
    }

    protected override async Task<IReadOnlyList<GetIdentityClaimResponseDTO>> HandleData(Unit unit, CancellationToken cancellationToken)
    {           
       var result= await _claimsRepository.GetReadClaims( cancellationToken); 
       var existingClaim= result.Select(x=>new GetIdentityClaimResponseDTO { Id=x.Id, ClaimName=x.ClaimName, ClaimUser=x.ClaimUser, ClaimValue=x.ClaimValue} ).ToList();
       return existingClaim;
    }
}
