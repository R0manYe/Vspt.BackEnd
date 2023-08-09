using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetAddClaimRequest : BaseRequest<GetClaimRequest, Unit>
    {
    }
    internal sealed class GetAddClaimHandler : BaseRequestHandler<GetAddClaimRequest, GetClaimRequest, Unit>
    {
        private readonly IClaimsRepository _claimsRepository;
        private readonly IMapper _mapper;


        public GetAddClaimHandler(IMapper mapper, IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
            _mapper = mapper;

        }

        protected override async Task<Unit> HandleData(GetClaimRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityClaims>(request);
            await _claimsRepository.AddClaim(user, cancellationToken);
            return Unit.Value;

        }
    }
}
