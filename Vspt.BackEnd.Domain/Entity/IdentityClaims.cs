using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed  class IdentityClaims : IEntityWithId
{       
    public Guid Id { get; set; }

    public string ClaimName { get; set; }

    public  ClaimType ClaimType { get; set; }

    public string ClaimValue { get; set; }    
}
