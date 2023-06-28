using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Vspt.BackEnd.Application.features.Authentication.Helpers;
using Vspt.Box.MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using MediatR;

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetAllUsersHandlerRequest : BaseRequest<Unit, List<User>>
    {
    }
    internal sealed class GetAllUsersHandlerHandler : BaseRequestHandler<GetAllUsersHandlerRequest, Unit, List<User>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
       
      

        public GetAllUsersHandlerHandler(IMapper mapper,  IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
          
         
        }

        protected override async Task<List<User>> HandleData(Unit unit, CancellationToken cancellationToken)
        {
          return await _usersRepository.GetAllUsers(cancellationToken);      
            
        }
    }
}
