using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Application.features.Authentication.DTO
{
    public record GetLoginRequestItem
    {
        // public required Guid id { get; init; }

        public required string FirstName { get; init; }

        public required string LastName { get; init; }

        public required string Username { get; init; }

        public required string Password { get; set; }

        public required string Token { get; set; }

        public required string Email { get; init; }

        public required string Role { get; set; }

        public required string RefreshToken { get; init; }

        public DateTime RefreshTokenExpiryTime { get; init; }

    }
    public record GetLoginRequestItemDto
    {
        public required GetLoginRequestItem Item { get; init; }
    }

}
