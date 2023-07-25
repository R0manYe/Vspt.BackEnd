﻿using AutoMapper;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Application.features.Authentication
{
    internal sealed class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<GetLoginRequestItem, User>();
            CreateMap<User, GetLoginRequestItem>();
        }
    }
}