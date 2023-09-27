using AutoMapper;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.Authentication
{
    internal sealed class ClaimsMapper : Profile
    {
        public ClaimsMapper() 
        {
            CreateMap<GetIdentityClaimRequestDTO, IdentityClaims>();
            CreateMap<IdentityClaims, GetIdentityClaimRequestDTO>();
        }
    }
}
