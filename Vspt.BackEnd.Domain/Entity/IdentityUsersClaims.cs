using System.Security.Claims;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class IdentityUsersClaims
    {        
        public Guid UserId { get; set; }
        public IdentityClaims IdentityUser { get; set; }
        public Guid ClaimId { get; set; }
        public IdentityClaims IdentityClaim { get; set; }
        public string ClaimValue {get; set; }
    }
}
