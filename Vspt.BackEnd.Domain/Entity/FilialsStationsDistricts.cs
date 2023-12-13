using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed class FilialsStationsDistricts : IEntity
{   
    public byte BuId { get; init; }
    public SprFilials Filials { get; init; }
    public ulong DistrictId { get; init; }
    public SprDistrict Districts { get; init; }
    public uint StationECPId { get; set; }
    public uint StationRZDId { get; set; }
}
