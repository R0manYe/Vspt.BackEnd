namespace Vspt.Common.Api.Contract.Postgrees.DTO.Auth
{
    public record GetLoginRequestItem
    {
        public required uint Username { get; set; }

        public required string Password { get; set; }


        public string Role { get; set; } = "user";

    }
    public record GetLoginRequestItemDto
    {
        public required GetLoginRequestItem Item { get; init; }
    }

}
