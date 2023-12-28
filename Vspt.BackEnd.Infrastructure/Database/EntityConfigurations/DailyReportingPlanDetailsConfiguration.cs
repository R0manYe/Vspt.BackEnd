using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class DailyReportingPlanDetailsConfiguration : IEntityTypeConfiguration<DailyReportingPlansDetails>
{
    public void Configure(EntityTypeBuilder<DailyReportingPlansDetails> builder)
    {
        builder
            .ToTable("DailyReportingPlanDetails");

        builder
            .HasKey(x =>x.Id);       
    }
}
