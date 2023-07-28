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
            .WithMany(x => x.identityUsersClaims)
            .HasForeignKey(x => x.UserId);
       
        builder
           .HasOne(x => x.IdentityClaims)
           .WithMany(x => x.IdentityUsersClaim)
           .HasForeignKey(x => x.ClaimId);
    }
}
