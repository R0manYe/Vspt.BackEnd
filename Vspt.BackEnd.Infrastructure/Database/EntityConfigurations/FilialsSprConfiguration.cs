using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class FilialsSprConfiguration : IEntityTypeConfiguration<FilialsSpr>
{
    public void Configure(EntityTypeBuilder<FilialsSpr> builder)
    {
        builder
            .ToTable("FilialsSpr");

        builder
            .HasKey(x =>x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);
        builder
           .Property(x => x.ShortName)
           .IsRequired()
           .HasMaxLength(20);

    }
}
