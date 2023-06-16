using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Vspt.BackEnd.Application.features.Authentication.Helpers;

namespace Vspt.BackEnd.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly PgContext _authContext;
            public UserController(PgContext appDbContext)
            {
                _authContext = appDbContext;
            }
            [HttpPost("authenticate")]
            public async Task<IActionResult> Authenticate([FromBody] User userObj)
            {
                if (userObj == null)
                    return BadRequest();

                var user = await _authContext.Users
                    .FirstOrDefaultAsync(x => x.Username == userObj.Username);
                if (user == null)
                    return NotFound(new { Message = "User not found!" });

                if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
                {
                    return BadRequest(new { Message = "Password is incorrect!" });
                }

                user.Token = CreateJWT(user);
                var newAccessToken = user.Token;
                var newRefreshToken = CreateRefreshtoken();
                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(5);
                await _authContext.SaveChangesAsync();

                return Ok(new TokenApiDto()
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken

                });
                ;
            }
            [HttpPost("register")]
            public async Task<IActionResult> RegisterUser([FromBody] User userObj)
            {
                if (userObj == null)
                    return BadRequest();
                //chech Username
                if (await CheckUserNameExistAsnc(userObj.Username))
                    return BadRequest(new { Message = "Username already Exists!" });
                //check Email
                if (await CheckUserEmailExistAsnc(userObj.Email))
                    return BadRequest(new { Message = "Email already Exists!" });

                //check Passw
                var pass = CheckPasswordExistAsnc(userObj.Password);
                if (!string.IsNullOrEmpty(pass))
                    return BadRequest(new { Message = pass.ToString() });


                userObj.Password = PasswordHasher.HashPassword(userObj.Password);
                userObj.Role = "User";
                userObj.Token = "";
                await _authContext.Users.AddAsync(userObj);
                await _authContext.SaveChangesAsync();
                return Ok(new
                {
                    Message = "User Registred!"
                });
            }
            private Task<bool> CheckUserNameExistAsnc(string userName)

                => _authContext.Users.AnyAsync(x => x.Username == userName);

            private Task<bool> CheckUserEmailExistAsnc(string Email)

                => _authContext.Users.AnyAsync(x => x.Email == Email);

            private string CheckPasswordExistAsnc(string Password)
            {
                StringBuilder sb = new StringBuilder();
                if (Password.Length < 8)
                    sb.Append("Minimum password lenght should be 8" + Environment.NewLine);
                if (!(Regex.IsMatch(Password, "[a-z]") && Regex.IsMatch(Password, "[A-Z]") && Regex.IsMatch(Password, "[0-9]")))
                    sb.Append("Password should be Alphanumeric" + Environment.NewLine);
                if (!(Regex.IsMatch(Password, "[<,>,&]")))
                    sb.Append("Password should be AlphanumericNew" + Environment.NewLine);
                return sb.ToString();
            }

            private string CreateJWT(User user)
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
            private string CreateRefreshtoken()
            {
                var tokenBytes = RandomNumberGenerator.GetBytes(64);
                var refreshToken = Convert.ToBase64String(tokenBytes);

                var tokenUser = _authContext.Users
                    .Any(a => a.RefreshToken == refreshToken);
                if (tokenUser)
                {
                    return CreateRefreshtoken();
                }
                return refreshToken;
            }

            private ClaimsPrincipal GetPrincipalFromExpiriedToken(string token)
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
            [HttpPost("Add")]
            public async Task<IActionResult> AddUser([FromBody] User userRequest)
            {

                await _authContext.Users.AddAsync(userRequest);
                await _authContext.SaveChangesAsync();
                return Ok(userRequest);
            }

            [Authorize]
            [HttpGet]
            public async Task<ActionResult<User>> GetAllUsers()
            {
                return Ok(await _authContext.Users.ToListAsync());
            }

            [HttpPost("refresh")]
            public async Task<IActionResult> Refresh(TokenApiDto tokenApiDto)
            {
                if (tokenApiDto is null)
                    return BadRequest("Invalid Client Request");
                string accessToken = tokenApiDto.AccessToken;
                string refreshToken = tokenApiDto.RefreshToken;
                var principal = GetPrincipalFromExpiriedToken(accessToken);
                var username = principal.Identity.Name;
                var user = await _authContext.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                    return BadRequest("Invalid request");
                var newAccessToken = CreateJWT(user);
                var newRefreshToken = CreateRefreshtoken();
                user.RefreshToken = newRefreshToken;
                await _authContext.SaveChangesAsync();
                return Ok(new TokenApiDto()
                {
                    AccessToken = accessToken,
                    RefreshToken = newRefreshToken
                });


            }

        }
    
}
