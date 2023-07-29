namespace Vspt.Common.Api.Contract.Postgrees.DTO.Auth
{
    public class GetLoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
    }
}
