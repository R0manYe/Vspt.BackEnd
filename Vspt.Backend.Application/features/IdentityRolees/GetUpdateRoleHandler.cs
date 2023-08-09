using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetUpdateRoleRequest : BaseRequest<IdentityRoles, Unit>
    {
    }
    internal sealed class GetUpdateRoleHandler : BaseRequestHandler<GetUpdateRoleRequest, IdentityRoles, Unit>
    {
        private readonly IRolesRepository _rolesRepository;      


        public GetUpdateRoleHandler(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository; 
        }

        protected override async Task<Unit> HandleData(IdentityRoles request, CancellationToken cancellationToken)
        {         
            await _rolesRepository.UpdateRoles(request, cancellationToken);
            return Unit.Value;
        }
    }
}
