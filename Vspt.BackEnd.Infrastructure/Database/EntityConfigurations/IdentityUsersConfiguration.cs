using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class IdentityUsersConfiguration : IEntityTypeConfiguration<IdentityUsers>
{
    public void Configure(EntityTypeBuilder<IdentityUsers> builder)
    {
        builder
            .ToTable("IdentityUsers");

        builder
            .HasKey(x => x.Username);

        builder
            .Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50);
    }
}
