namespace Vspt.Common.Api.Contract.Postgrees.DTO.Auth
{
    public record GetLoginRequestItem
    {
        public required string Username { get; set; }

        public required string Password { get; set; }

        public string? Token { get; set; }


        public string? Role { get; set; }

      /*  public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }*/

    }
    public record GetLoginRequestItemDto
    {
        public required GetLoginRequestItem Item { get; init; }
    }

}
