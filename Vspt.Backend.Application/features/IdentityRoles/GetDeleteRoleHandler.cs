using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.Role;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetDeleteRoleRequest : BaseRequest<GetDeleteRoleRequestDTO, Unit>
    {
    }
    internal sealed class GetDeleteRoleHandler : BaseRequestHandler<GetDeleteRoleRequest, GetDeleteRoleRequestDTO, Unit>
    {
        private readonly IRolesRepository _rolesRepository;       

        public GetDeleteRoleHandler(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        protected override async Task<Unit> HandleData(GetDeleteRoleRequestDTO request, CancellationToken cancellationToken)
        {         
            await _rolesRepository.DeleteRoles(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
