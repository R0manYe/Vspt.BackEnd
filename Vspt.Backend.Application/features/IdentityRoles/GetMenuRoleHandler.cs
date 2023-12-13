using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contract.Postgrees.ViewModels;


namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetMenuRoleRequest : BaseRequest<uint, IReadOnlyList<GetFilterIdRequestDTO>>
    {
    }
    internal sealed class GetMenuRoleHandler : BaseRequestHandler<GetMenuRoleRequest, uint, IReadOnlyList<GetFilterIdRequestDTO>>
    {       
        private readonly IIdentityClaimsRepository _identityClaimsRepository;

        public GetMenuRoleHandler( IIdentityClaimsRepository identityClaimsRepository)
        {
            _identityClaimsRepository = identityClaimsRepository;
        }

        protected override async Task<IReadOnlyList<GetFilterIdRequestDTO>> HandleData(uint userId, CancellationToken cancellationToken)
        { 
             return await _identityClaimsRepository.GetFilterClaim(userId,(byte)TypeClaim.Roles,cancellationToken);
        }
    }
}