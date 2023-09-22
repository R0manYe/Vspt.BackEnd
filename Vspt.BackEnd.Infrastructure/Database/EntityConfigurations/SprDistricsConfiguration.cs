using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class SprDistricsConfiguration : IEntityTypeConfiguration<SprDistrict>
{
    public void Configure(EntityTypeBuilder<SprDistrict> builder)
    {
        builder
            .ToTable("SprDistricts");

        builder
            .HasKey(x =>x.id);
        builder
            .HasOne(x => x.SprFilial)
            .WithMany()
            .HasForeignKey(x => x.Bu_id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
