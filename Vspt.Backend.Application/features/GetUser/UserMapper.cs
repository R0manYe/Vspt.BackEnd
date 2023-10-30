using AutoMapper;
using MassTransit.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.GetUser
{
    internal sealed class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<IdentityUsers, GetUserDTO>();

            CreateMap<GetUserDTO,IdentityUsers>();           
        }
    }
}
