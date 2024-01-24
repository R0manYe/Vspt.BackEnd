using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class DailyReportingDvigenConfiguration : IEntityTypeConfiguration<DailyReportingDvigen>
{
    public void Configure(EntityTypeBuilder<DailyReportingDvigen> builder)
    {
        builder
            .ToTable("DailyReportingDvigen");

        builder
            .HasKey(x =>x.Id);       
    }
}
