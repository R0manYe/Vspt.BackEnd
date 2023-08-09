using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity;

public sealed  class IdentityClaims : IEntityWithId
{       
    public Guid Id { get; set; }
    public string? ClaimName { get; set; }   
}
