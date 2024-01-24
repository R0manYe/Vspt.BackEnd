using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed  class DailyReportingDvigen : IEntityWithId
{
    public Guid Id { get; set; }
    public DateTime DateDvigenReporting { get; set; }
    public string idFilial { get; set; }
    public string idDistrict { get; set; }
}
