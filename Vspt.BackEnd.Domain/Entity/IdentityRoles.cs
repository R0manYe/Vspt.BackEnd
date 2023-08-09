using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class IdentityRoles : IEntityWithId
    {
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
    }
}