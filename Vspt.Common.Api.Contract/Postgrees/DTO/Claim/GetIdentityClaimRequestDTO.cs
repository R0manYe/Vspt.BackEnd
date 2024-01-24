namespace Vspt.Common.Api.Contract.Postgrees.DTO.Claim
{
    public record GetIdentityClaimRequestDTO
    {       
        public byte ClaimName { get; set; }      
        public uint ClaimUser { get; set; }
        public uint ClaimValue { get; set; }
    }

}
