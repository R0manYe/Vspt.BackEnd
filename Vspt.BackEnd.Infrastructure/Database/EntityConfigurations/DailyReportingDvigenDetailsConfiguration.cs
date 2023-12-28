using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class DailyReportingDvigenDetailsConfiguration : IEntityTypeConfiguration<DailyReportingDvigenDetails>
{
    public void Configure(EntityTypeBuilder<DailyReportingDvigenDetails> builder)
    {
        builder
            .ToTable("DailyReportingDvigenDetails");

        builder
            .HasKey(x =>x.Id);       
    }
}
