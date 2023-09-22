namespace Vspt.Common.Api.Contract.Postgrees.DTO.Claim
{
    public record GetClaimRequest
    {
        public string ClaimName { get; set; }       
        public string ClaimValue { get; set; }

    }

}
