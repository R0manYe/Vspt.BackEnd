using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class IdentityUsersClaimsConfiguration : IEntityTypeConfiguration<IdentityUsersClaims>
{
    public void Configure(EntityTypeBuilder<IdentityUsersClaims> builder)
    {      

        builder
            .HasKey(x => new {x.ClaimId,x.UserId});

        builder
            .HasOne(x => x.IdentityUser)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder
           .HasOne(x => x.IdentityClaim)
           .WithMany()
           .HasForeignKey(x => x.ClaimId);
    }
}
