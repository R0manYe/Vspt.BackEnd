using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record UpdateClaimRequest : BaseRequest<IdentityClaims, Unit>
    {
    }
    internal sealed class UpdateClaimHandler : BaseRequestHandler<UpdateClaimRequest, IdentityClaims, Unit>
    {
        private readonly IIdentityClaimsRepository _claimsRepository; 

        public UpdateClaimHandler(IIdentityClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
        }

        protected override async Task<Unit> HandleData(IdentityClaims request, CancellationToken cancellationToken)
        {         
            await _claimsRepository.UpdateClaim(request, cancellationToken);
            return Unit.Value;
        }
    }
}
