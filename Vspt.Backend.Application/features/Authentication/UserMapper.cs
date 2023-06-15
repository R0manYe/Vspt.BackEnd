using AutoMapper;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Application.features.Authentication
{
    internal sealed class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<GetLoginRequestItem, User>();
        }
    }
}
