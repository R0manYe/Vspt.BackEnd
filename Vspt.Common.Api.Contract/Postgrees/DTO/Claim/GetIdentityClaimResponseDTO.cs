namespace Vspt.Common.Api.Contract.Postgrees.DTO.Claim
{
    public record GetIdentityClaimResponseDTO
    {
        public Guid Id { get; set; }
        public byte ClaimName { get; set; }      
        public string ClaimUser { get; set; }
        public string ClaimValue { get; set; }

    }

}
