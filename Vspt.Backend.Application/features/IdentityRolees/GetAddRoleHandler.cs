using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetAddRoleRequest : BaseRequest<GetRoleRequest, Unit>
    {
    }
    internal sealed class GetAddRoleHandler : BaseRequestHandler<GetAddRoleRequest, GetRoleRequest, Unit>
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;


        public GetAddRoleHandler(IMapper mapper, IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;

        }

        protected override async Task<Unit> HandleData(GetRoleRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityRoles>(request);
            await _rolesRepository.AddRoles(user, cancellationToken);
            return Unit.Value;

        }
    }
}
