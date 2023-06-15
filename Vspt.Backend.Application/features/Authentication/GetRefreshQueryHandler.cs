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
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading;
using Vspt.BackEnd.Application.features.Authentication;

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetRefreshRequest : BaseRequest<GetLoginRequestItem, Unit>
    {
    }
    internal sealed class GetRefreshQueryHandler : BaseRequestHandler<GetRefreshRequest, GetLoginRequestItem, Unit>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
      

        public GetRefreshQueryHandler(IMapper mapper,  IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
         
        }

        protected override async Task<Unit> HandleData(GetLoginRequestItem request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _usersRepository.Add(user, cancellationToken);
            
            return Unit.Value;

        }
    }
}
