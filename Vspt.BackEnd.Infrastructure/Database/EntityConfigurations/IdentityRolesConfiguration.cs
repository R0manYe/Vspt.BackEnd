using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRoles>
{
    public void Configure(EntityTypeBuilder<IdentityRoles> builder)
    {
        builder
            .ToTable("IdentityRoles");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.RoleName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasMany(x => x.IdentityUsersRole)
            .WithOne()
            .HasForeignKey(x => x.RoleId);
    }
}
