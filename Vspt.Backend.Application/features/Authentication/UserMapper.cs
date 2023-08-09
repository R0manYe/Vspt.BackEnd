using AutoMapper;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;

namespace Vspt.BackEnd.Application.features.Authentication;

internal sealed class UserMapper : Profile
{
    public UserMapper() 
    {
        CreateMap<GetLoginRequestItem, IdentityUsers>();
        CreateMap<IdentityUsers, GetLoginRequestItem>();            
    }
}
