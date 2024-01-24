using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class DailyReportingPlans : IEntityWithId
    {
        public Guid Id { get; set; }
        public DateTime DatePlanReporting { get; set; }
        public byte idFilial { get; set; }
        public string idDistrict { get; set; }
    }
}