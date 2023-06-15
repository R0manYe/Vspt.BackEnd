using AngularAuthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetLoginRequestItem
    {
        public int id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

    }
    public record GetLoginRequestItemDto
    {
        public required List<GetLoginRequestItem> Items { get; init; }
    }

}
