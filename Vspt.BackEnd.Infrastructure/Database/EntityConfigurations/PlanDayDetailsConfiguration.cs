using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class PlanDayDetailsConfiguration : IEntityTypeConfiguration<PlanDayDtails>
{
    public void Configure(EntityTypeBuilder<PlanDayDtails> builder)
    {
        builder
            .ToTable("PlanDayDetails");

        builder
            .HasKey(x =>x.Id); 
    }
}
