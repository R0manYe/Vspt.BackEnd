using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class IdentityClaimsConfiguration : IEntityTypeConfiguration<IdentityClaims>
{
    public void Configure(EntityTypeBuilder<IdentityClaims> builder)
    {
        builder
            .ToTable("IdentityClaims");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.ClaimName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasMany(x => x.IdentityUsersClaim)
            .WithOne()
            .HasForeignKey(x => x.ClaimId);
    }
}
