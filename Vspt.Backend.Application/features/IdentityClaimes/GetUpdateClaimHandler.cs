using AutoMapper;
using MediatR;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetUpdateClaimRequest : BaseRequest<IdentityClaims, Unit>
    {
    }
    internal sealed class GetUpdateClaimHandler : BaseRequestHandler<GetUpdateClaimRequest, IdentityClaims, Unit>
    {
        private readonly IClaimsRepository _claimsRepository;
        private readonly IMapper _mapper;


        public GetUpdateClaimHandler(IMapper mapper, IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
            _mapper = mapper;

        }

        protected override async Task<Unit> HandleData(IdentityClaims request, CancellationToken cancellationToken)
        {
         
            await _claimsRepository.UpdateClaim(request, cancellationToken);
            return Unit.Value;

        }
    }
}
