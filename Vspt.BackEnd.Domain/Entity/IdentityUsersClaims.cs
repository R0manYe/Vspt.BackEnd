using System.Security.Claims;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class IdentityUsersClaims
    {  
        public string UserId { get; set; }
        public IdentityUsers IdentityUser { get; set; }
        public Guid ClaimId { get; set; }
        public IdentityClaims IdentityClaim { get; set; }       
    }
}
