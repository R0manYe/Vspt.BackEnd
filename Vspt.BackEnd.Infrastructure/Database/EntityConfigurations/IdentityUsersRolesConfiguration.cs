using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class IdentityUsersRolesConfiguration : IEntityTypeConfiguration<IdentityUsersRoles>
{
    public void Configure(EntityTypeBuilder<IdentityUsersRoles> builder)
    {      

        builder
            .HasKey(x => new {x.RoleId,x.UserId});

        builder
            .HasOne(x => x.IdentityUser)
            .WithMany()
            .HasForeignKey(x => x.UserId);
       
        builder
           .HasOne(x => x.IdentityRole)
           .WithMany()
           .HasForeignKey(x => x.RoleId);
    }
}
