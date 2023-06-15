using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");

        builder
            .HasKey(x => x.id);

        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder
        .HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.Role.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
       .HasOne(x => x.Filter)
           .WithMany()
           .HasForeignKey(x => x.Filter.Id)
           .OnDelete(DeleteBehavior.Restrict);

    }
}
