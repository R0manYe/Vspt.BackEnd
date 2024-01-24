using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record AddClaimRequest : BaseRequest<GetIdentityClaimRequestDTO, Unit>
    {
    }
    internal sealed class AddClaimHandler : BaseRequestHandler<AddClaimRequest, GetIdentityClaimRequestDTO, Unit>
    {
        private readonly IIdentityClaimsRepository _identityclaimsRepository;
        private readonly IMapper _mapper;


        public AddClaimHandler(IMapper mapper, IIdentityClaimsRepository identityClaimsRepository)
        {
            _identityclaimsRepository = identityClaimsRepository;
            _mapper = mapper;

        }

        protected override async Task<Unit> HandleData(GetIdentityClaimRequestDTO request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityClaims>(request);
            await _identityclaimsRepository.AddIdentityClaim(user, cancellationToken);
            return Unit.Value;

        }
    }
}
