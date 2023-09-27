using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetAddRoleRequest : BaseRequest<string, Unit>
    {
    }
    internal sealed class GetAddRoleHandler : BaseRequestHandler<GetAddRoleRequest, string, Unit>
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;


        public GetAddRoleHandler(IMapper mapper, IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;

        }

        protected override async Task<Unit> HandleData(string request, CancellationToken cancellationToken)
        {
            var model=new IdentityRoles { Id=Guid.NewGuid(), RoleName=request};
            await _rolesRepository.AddRoles(model, cancellationToken);
            return Unit.Value;
        }
    }
}
