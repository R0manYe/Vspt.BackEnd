using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity;

public sealed class DailyReportingPlansDetails : IEntityWithId
{
    public Guid Id { get; set; }
    public DateTime DatePlan { get; set; }
    public byte BuId { get; set; }
    public SprFilials SprFilials { get; set; }
    public string OrgId { get; set; }
    public string GruzGroupId { get; set; }
    //Погрузка
    public int? LoadingPlan { get; set; }   
    public int? LoadingApplication { get; set; }   
    public int? LoadingSecuredTotal { get; set; }   
    public int? LoadingSecuredLastDay { get; set; }   
    public int? ExpectedLoading { get; set; }     
    public int? LoadingPPGT { get; set; }   
    public int? LoadingFirstHalfDay { get; set; }   
    //Выгрузка
    public int? UnloadingPlan { get; set; }   
    public int? UnloadingRemainsLastDay { get; set; }   
    public int? UnloadingAccesptedTotal { get; set; }   
    public int? UnloadingAccesptedFullTerm { get; set; }
    public int? UnloadingProduceTotal { get; set; }
    public int? UnloadingProduceFullTerm { get; set; }
    public int? UnloadingExpectedLoading { get; set; }   
    public int? UnloadingAccesptedPPGT { get; set; }
    public int? UnloadingAccesptedLastDayWagons { get; set; }
    public int? UnloadingRemainsTotal { get; set; }
    public int? UnloadingRemainsFullTerm { get; set; }
    public int? UnloadingRemainsGuiltPPGT { get; set; }
    public int? UnloadingRemainsGuiltConsignee { get; set; }
    public int? Notations { get; set; }
}
