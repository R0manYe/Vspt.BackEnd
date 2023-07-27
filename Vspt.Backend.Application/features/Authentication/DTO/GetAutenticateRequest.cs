namespace Vspt.BackEnd.Application.features.Authentication.DTO
{
    public record GetAutenticateRequest
    {
        public required string Username { get; set; }

        public required string Password { get; set; }
    }

}
