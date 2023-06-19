using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Application.features.Authentication.DTO
{
    public record GetLoginRequestItem
    {       

        public  string? FirstName { get; set; }

        public  string? LastName { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public  string? Token { get; set; }

        public  string? Email { get; set; }

        public  string? Role { get; set; }

        public  string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

    }
    public record GetLoginRequestItemDto
    {
        public required GetLoginRequestItem Item { get; init; }
    }

}
