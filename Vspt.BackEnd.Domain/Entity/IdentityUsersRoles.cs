using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class IdentityUsersRoles
    {        
        public Guid UserId { get; set; }
        public IdentityUsers IdentityUser { get; set; }
        public Guid RoleId { get; set; }
        public IdentityRoles IdentityRole { get; set; }
    }
}
