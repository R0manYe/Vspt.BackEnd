using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetDeleteClaimRequest : BaseRequest<Guid, Unit>
    {
    }
    internal sealed class GetDeleteClaimHandler : BaseRequestHandler<GetDeleteClaimRequest, Guid, Unit>
    {
        private readonly IIdentityClaimsRepository _claimsRepository;
        


        public GetDeleteClaimHandler(IIdentityClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
           

        }

        protected override async Task<Unit> HandleData(Guid request, CancellationToken cancellationToken)
        {
         
            await _claimsRepository.DeleteClaim(request, cancellationToken);
            return Unit.Value;

        }
    }
}
