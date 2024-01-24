namespace Vspt.Common.Api.Contract.Postgrees.DTO.Claim
{
    public record GetUserFullDTO
    {
        public string Username { get; set; }

        public string? Password { get; set; }  

        public string? Role { get; set; }
      
    }

}
