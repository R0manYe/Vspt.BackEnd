using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed  class SprSvod
{      
    public byte claimname { get; set; }   
    public string Id { get; set; }   
    public string name { get; set; }   
}
