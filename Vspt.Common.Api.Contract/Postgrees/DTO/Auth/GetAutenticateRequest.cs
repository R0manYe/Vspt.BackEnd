namespace Vspt.Common.Api.Contract.Postgrees.DTO.Auth
{
    public record GetAutenticateRequest
    {
        public required string Username { get; set; }

        public required string Password { get; set; }
    }

}
