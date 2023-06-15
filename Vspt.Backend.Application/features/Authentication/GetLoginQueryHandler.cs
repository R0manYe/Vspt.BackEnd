using MediatR;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Vspt.BackEnd.Application.Authentication.Auth;

namespace Vspt.Backend.Application.features.Authentication
{
    public sealed record GetLoginRequest : IRequest<GetLoginRequestItem, GetLoginResponse>
    {
    }


    internal sealed class GetLoginQueryHandler : IRequestHandler<GetLoginRequest, GetLoginRequestItem, GetLoginResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetLoginQueryHandler(IMapper mapper, IDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        protected override async Task<GetLoginResponse> HandleData(GetLoginRequestItem request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            // var user= await _dbContext.Users.ProjectTo<GetLoginRequestItem>(_mapper.ConfigurationProvider).ToListAsync();
            var user = await _dbContext.Users.Where(x => x.Username == request.Username).FirstOrDefaultAsync();
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
            await _dbContext.SaveToDbAsync();

            return new GetLoginResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken

            };


            static string CreateJWT(User user)
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

                var tokenUser = _dbContext.Users
                    .Any(a => a.RefreshToken == refreshToken);
                if (tokenUser)
                {
                    return CreateRefreshtoken();
                }
                return refreshToken;
            }
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
        }
    }
}
