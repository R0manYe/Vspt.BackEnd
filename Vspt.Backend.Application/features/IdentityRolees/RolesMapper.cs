using AutoMapper;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityRolees
{
    internal sealed class RolesMapper : Profile
    {
        public RolesMapper()
        {
            CreateMap<GetRoleRequest, IdentityRoles>();
            CreateMap<IdentityRoles, GetRoleRequest>();
        }
    }
}
