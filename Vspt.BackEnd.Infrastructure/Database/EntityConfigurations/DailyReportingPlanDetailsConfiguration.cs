using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class DailyReportingPlanDetailsConfiguration : IEntityTypeConfiguration<DailyReportingPlanDetails>
{
    public void Configure(EntityTypeBuilder<DailyReportingPlanDetails> builder)
    {
        builder
            .ToTable("DailyReportingPlanDetails");

        builder
            .HasKey(x =>x.Id);
        builder
         .HasOne(x => x.DailyReportingPlan)
         .WithMany()
         .HasForeignKey(x => x.PlanId);
    }
}
