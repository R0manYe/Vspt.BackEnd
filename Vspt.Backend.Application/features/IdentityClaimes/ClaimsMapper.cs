using AutoMapper;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;

namespace Vspt.BackEnd.Application.features.Authentication
{
    internal sealed class ClaimsMapper : Profile
    {
        public ClaimsMapper() 
        {
            CreateMap<GetClaimRequest, IdentityClaims>();
            CreateMap<IdentityClaims, GetClaimRequest>();
        }
    }
}
