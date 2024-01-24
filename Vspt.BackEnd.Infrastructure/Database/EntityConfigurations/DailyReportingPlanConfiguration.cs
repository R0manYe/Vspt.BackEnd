using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class DailyReportingPlanConfiguration : IEntityTypeConfiguration<DailyReportingPlans>
{
    public void Configure(EntityTypeBuilder<DailyReportingPlans> builder)
    {
        builder
            .ToTable("DailyReportingPlan");

        builder
            .HasKey(x =>x.Id);       
    }
}
