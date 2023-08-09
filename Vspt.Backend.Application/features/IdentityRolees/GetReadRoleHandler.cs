using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityRolees
{
    public sealed record GetReadRoleRequest : BaseRequest<Unit, IReadOnlyList<IdentityRoles>>
    {
    }
    internal sealed class GetReadRoleHandler : BaseRequestHandler<GetReadRoleRequest, Unit, IReadOnlyList<IdentityRoles>>
    {
        private readonly IRolesRepository _rolesRepository;


        public GetReadRoleHandler(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        protected override async Task<IReadOnlyList<IdentityRoles>> HandleData(Unit unit, CancellationToken cancellationToken)
        {
            return await _rolesRepository.GetReadRoles(cancellationToken);
        }
    }
}
