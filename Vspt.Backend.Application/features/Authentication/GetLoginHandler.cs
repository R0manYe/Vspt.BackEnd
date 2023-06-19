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
    internal sealed class GetLoginHandler : BaseRequestHandler<GetLoginRequest, GetLoginRequestItem, GetLoginResponse>
    {
        private readonly IUsersRepository _usersRepository;       
        private readonly PgContext _pgContext;
      

        public GetLoginHandler(IUsersRepository usersRepository, PgContext pgContext)
        {
            _usersRepository = usersRepository;           
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

            user.Token = GeneratorGWT.CreateJWT(user);
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
