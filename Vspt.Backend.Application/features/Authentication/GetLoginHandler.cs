using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Vspt.BackEnd.Application.features.Authentication.Helpers;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetLoginRequest : BaseRequest<GetAutenticateRequest, GetLoginResponse>
    {
    }
    internal sealed class GetLoginHandler : BaseRequestHandler<GetLoginRequest, GetAutenticateRequest, GetLoginResponse>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly PgContext _pgContext;


        public GetLoginHandler(IUsersRepository usersRepository, PgContext pgContext)
        {
            _usersRepository = usersRepository;
            _pgContext = pgContext;

        }

        protected override async Task<GetLoginResponse> HandleData(GetAutenticateRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var user = await _usersRepository.GetByUserNamePsw(request.Username, request.Password, cancellationToken);


            if (user == null)
            {
                throw new ArgumentNullException("user not found");
            }

            if (request.Password != user.Password)
            {
                throw new ArgumentNullException("Password is incorrect!");
            }

            user.Token = GeneratorGWT.CreateJWT(user);
            var newAccessToken = user.Token;
            var newRefreshToken = CreateRefreshtoken();
            user.RefreshToken = newRefreshToken.Result;
            await _pgContext.SaveChangesAsync();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(5);
            await _usersRepository.GetBySaveToken(user, cancellationToken);

            return new GetLoginResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Result,
                Username = request.Username

            };

            async Task<string> CreateRefreshtoken()
            {
                var tokenBytes = RandomNumberGenerator.GetBytes(64);
                var refreshToken = Convert.ToBase64String(tokenBytes);

                var tokenUser = await _usersRepository.GetByToken(refreshToken, cancellationToken);
                if (tokenUser)
                {
                    return await CreateRefreshtoken();
                }
                return refreshToken;
            }
        }
        private ClaimsPrincipal GetPrincipalFromExpiriedToken(string token)
        {
            var key = Encoding.ASCII.GetBytes("VerisecretKeyFromAbakanForKrasnoyarsk");
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
                throw new SecurityTokenException("Недопустимый токен");
            return principal;
        }

    }
}
    

