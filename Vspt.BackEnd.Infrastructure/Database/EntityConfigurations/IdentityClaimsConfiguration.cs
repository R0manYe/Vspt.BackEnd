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
           .HasKey(x => new { x.Id});
       /* builder
            .HasAlternateKey(x => new {x.ClaimUser,x.ClaimName,x.ClaimValue});*/

        builder
           .HasOne(x => x.IdentityUser)
           .WithMany()
           .HasForeignKey(x => x.ClaimUser);
        builder
          .HasOne(x => x.TypeClaim)
          .WithMany()
          .HasForeignKey(x => x.ClaimName);


    }
}
