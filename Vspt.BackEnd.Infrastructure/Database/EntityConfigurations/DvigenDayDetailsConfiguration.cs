using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class DvigenDayDetailsConfiguration : IEntityTypeConfiguration<DvigenDayDtails>
{
    public void Configure(EntityTypeBuilder<DvigenDayDtails> builder)
    {
        builder
            .ToTable("DvigenDayDtails");

        builder
            .HasKey(x =>x.Id); 
    }
}
