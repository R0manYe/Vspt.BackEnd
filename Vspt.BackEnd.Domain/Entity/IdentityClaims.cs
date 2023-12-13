using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed  class IdentityClaims : IEntityWithId
{       
    public Guid Id { get; set; }
    public byte ClaimName { get; set; }
    public TypeClaims  TypeClaim { get; set; }
    public IdentityUsers IdentityUser { get; set; }
    public uint ClaimUser { get; set; }    
    public uint ClaimValue { get; set; }    
}
