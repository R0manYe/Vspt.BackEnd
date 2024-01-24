using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed  class SprSvod
{      
    public byte spr { get; set; }   
    public ulong Id { get; set; }   
    public string name { get; set; }   
}
