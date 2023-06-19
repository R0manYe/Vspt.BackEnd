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

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetLoginRequest : BaseRequest<GetLoginRequestItem, GetLoginResponse>
    {
    }
    internal sealed class GetLoginQueryHandler : BaseRequestHandler<GetLoginRequest, GetLoginRequestItem, GetLoginResponse>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly PgContext _pgContext;
      

        public GetLoginQueryHandler(IMapper mapper,  IUsersRepository usersRepository, PgContext pgContext)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _pgContext = pgContext;
         
        }

        protected override async Task<GetLoginResponse> HandleData(GetLoginRequestItem request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
          
            var user = await _usersRepository.GetByUserName(request.Username, cancellationToken);         
          
           
            if (user == null)
            {
                throw new ArgumentNullException("user not found");
            }

            if (!PasswordHasher.VerifyPassword(request.Password, user.Password))
            {
                throw new ArgumentNullException("Password is incorrect!");
            }

            user.Token = CreateJWT(user);
            var newAccessToken = user.Token;
            var newRefreshToken = CreateRefreshtoken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(5);
            await _pgContext.SaveChangesAsync();

            return new GetLoginResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken

            };


             string CreateJWT(User user)
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("Verisecret1234567890fdsf/");
                var identity = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name,$"{user.Username}"),
                });
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = DateTime.Now.AddDays(5),
                    SigningCredentials = credentials
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);

                return jwtTokenHandler.WriteToken(token);
            }
             string CreateRefreshtoken()
            {
                var tokenBytes = RandomNumberGenerator.GetBytes(64);
                var refreshToken = Convert.ToBase64String(tokenBytes);

                var tokenUser = _usersRepository.GetByToken(newAccessToken, cancellationToken);
                if (tokenUser is null)
                {
                    return CreateRefreshtoken();
                }
                return refreshToken;
            }
            
        }
    }
}
