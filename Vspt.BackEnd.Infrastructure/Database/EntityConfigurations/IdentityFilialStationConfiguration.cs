using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class IdentityFilialStationConfiguration : IEntityTypeConfiguration<IdentityFilialStation>
{
    public void Configure(EntityTypeBuilder<IdentityFilialStation> builder)
    {
        builder
            .ToTable("IdentityFilialStation");

        builder
            .HasKey(x => new {x.FilialId,x.StationId});

        builder
            .HasOne(x => x.Filials)
            .WithMany()
            .HasForeignKey(x => x.FilialId);

    }
}
