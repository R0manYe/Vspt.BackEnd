﻿using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed  class IdentityClaims : IEntityWithId
{       
    public Guid Id { get; set; }
    public byte ClaimName { get; set; }
    public TypeClaims  TypeClaim { get; set; }
    public IdentityUsers IdentityUser { get; set; }
    public string ClaimUser { get; set; }    
    public string ClaimValue { get; set; }    
}
