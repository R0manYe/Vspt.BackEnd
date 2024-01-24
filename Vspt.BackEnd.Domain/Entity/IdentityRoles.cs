using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class IdentityRoles : IEntity
    {
        public byte Id { get; set; }
        public string? RoleName { get; set; }
    }
}