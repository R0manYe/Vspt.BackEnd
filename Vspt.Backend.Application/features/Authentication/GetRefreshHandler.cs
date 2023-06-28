using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Application.features.Authentication.Helpers;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetRefreshRequest : BaseRequest<TokenApiDto, Unit>
    {
    }
    internal sealed class GetRefreshHandler : BaseRequestHandler<GetRefreshRequest, TokenApiDto, Unit>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly PgContext _pgContext;
         
      

        public GetRefreshHandler(IMapper mapper,  IUsersRepository usersRepository, PgContext pgContext)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _pgContext = pgContext;
         
        }

        protected override async Task<Unit> HandleData(TokenApiDto tokenApiDto, CancellationToken cancellationToken)
        {
            if (tokenApiDto is null)            
                throw new ValidationException("Invalid Client Request.");            
           
            string accessToken = tokenApiDto.AccessToken;
            string refreshToken = tokenApiDto.RefreshToken;
            
            var principal = GetPrincipalFromExpiriedToken(accessToken);
            
            var username = principal.Identity.Name;

            var user = await _usersRepository.GetByUserName(username, cancellationToken);
            
           // var user = await _authContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new ValidationException("Invalid request");
            //  return BadRequest("Invalid request");
            var newAccessToken = CreateJWT(user);               
            var newRefreshToken = CreateRefreshtoken();
            user.RefreshToken = newRefreshToken;
            await _pgContext.SaveChangesAsync();

            return Unit.Value;//return new TokenApiDto()
            //{
            //    AccessToken = accessToken,
            //    RefreshToken = newRefreshToken
            //};

            ClaimsPrincipal GetPrincipalFromExpiriedToken(string token)
            {
                var key = Encoding.ASCII.GetBytes("Verisecret1234567890fdsf/");
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = false
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("This is invalid token");
                return principal;
            }
            string CreateRefreshtoken()
            {
                var tokenBytes = RandomNumberGenerator.GetBytes(64);
                var refreshToken = Convert.ToBase64String(tokenBytes);

                var tokenUser = _usersRepository.GetByToken(refreshToken, cancellationToken);
                if (tokenUser is null)
                {
                    return CreateRefreshtoken();
                }
                return refreshToken;
            }
             string CreateJWT(User user)
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("Verisecret1234567890fdsf/");
                var identity = new ClaimsIdentity(new Claim[]
                {
                //new Claim(ClaimTypes.Role, user.Role.Id),
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

        }
    }
}
