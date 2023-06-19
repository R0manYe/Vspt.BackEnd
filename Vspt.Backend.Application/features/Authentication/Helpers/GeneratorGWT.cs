using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Application.features.Authentication.Helpers
{
    public static class GeneratorGWT
    {
        public static string CreateJWT(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("VerisecretKeyFromAbakanForKrasnoyarsk");
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
    }
}
