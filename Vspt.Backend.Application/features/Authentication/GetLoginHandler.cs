using System.Security.Cryptography;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Application.features.Authentication.Helpers;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.MediatR;

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
          
            var user = await _usersRepository.GetByUserNamePsw(request.Username,request.Password, cancellationToken);         
          
           
            if (user == null)
            {
                throw new ArgumentNullException("user not found");
            }

       //     if (!PasswordHasher.VerifyPassword(request.Password, user.Password))
            if ((request.Password!= user.Password))
            {
                throw new ArgumentNullException("Password is incorrect!");
            }

            user.Token = GeneratorGWT.CreateJWT(user);
            var newAccessToken = user.Token;
            var newRefreshToken = CreateRefreshtoken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(5);
            await _usersRepository.GetBySaveToken(user, cancellationToken);

            return new GetLoginResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                Username= request.Username

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
