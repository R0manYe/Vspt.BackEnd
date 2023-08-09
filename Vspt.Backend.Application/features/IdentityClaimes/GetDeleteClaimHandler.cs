using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetDeleteClaimRequest : BaseRequest<GetDeleteClaimRequestDTO, Unit>
    {
    }
    internal sealed class GetDeleteClaimHandler : BaseRequestHandler<GetDeleteClaimRequest, GetDeleteClaimRequestDTO, Unit>
    {
        private readonly IClaimsRepository _claimsRepository;
        


        public GetDeleteClaimHandler(IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
           

        }

        protected override async Task<Unit> HandleData(GetDeleteClaimRequestDTO request, CancellationToken cancellationToken)
        {
         
            await _claimsRepository.DeleteClaim(request.Id, cancellationToken);
            return Unit.Value;

        }
    }
}
