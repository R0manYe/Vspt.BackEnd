using System.Security.Claims;
using Vspt.Box.Data.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Domain.Entity;

public sealed  class DailyReportingDvigenDetails : IEntityWithId
{
    public Guid Id { get; set; }
    public DateOnly DateDvig { get; set; }
    public byte BuId { get; set; }   
    public SprFilials SprFilials { get; set; }
    public string OrgId { get; set; }
    public string GruzGroupId { get; set; }
    //Погрузка
    public int? LoadingPlan { get; set; }
    public int? LoadingApplication { get; set; }
    public int? LoadingSecuredTotal { get; set; }
    public int? LoadingSecuredLastDay { get; set; }
    public int? LoadingTotalWagons { get; set; }
    public int? LoadingTotalTonns { get; set; }
    public int? LoadingPPGT { get; set; }
    public int? LoadingFirstHalfDay { get; set; }
    //Выгрузка
    public int? UnloadingPlan { get; set; }
    public int? UnloadingRemainsLastDay { get; set; }
    public int? UnloadingAccesptedTotal { get; set; }
    public int? UnloadingAccesptedFullTerm { get; set; }
    public int? UnloadingProduceTotal { get; set; }
    public int? UnloadingProduceFullTerm { get; set; }
    public int? UnloadingAccesptedTotalWagons { get; set; }
    public int? UnloadingAccesptedTotalTonns { get; set; }
    public int? UnloadingAccesptedPPGT { get; set; }
    public int? UnloadingAccesptedLastDayWagons { get; set; }
    public int? UnloadingRemainsTotal { get; set; }
    public int? UnloadingRemainsFullTerm { get; set; }
    public int? UnloadingRemainsGuiltPPGT { get; set; }
    public int? UnloadingRemainsGuiltConsignee { get; set; }
    public int? Notations { get; set; }
}
