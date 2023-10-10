using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed class FilialsStationsDistricts : IEntity
{   
    public string BuId { get; init; }
    public SprFilials Filials { get; init; }
    public string DistrictId { get; init; }
    public SprDistrict Districts { get; init; }
    public string StationECPId { get; set; }
    public string StationRZDId { get; set; }
}
