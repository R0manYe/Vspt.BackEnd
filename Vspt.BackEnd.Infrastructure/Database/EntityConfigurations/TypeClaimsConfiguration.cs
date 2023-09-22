using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class TypeClaimsConfiguration : IEntityTypeConfiguration<TypeClaims>
{
    public void Configure(EntityTypeBuilder<TypeClaims> builder)
    {
        builder
            .ToTable("TypeClaims");

        builder
            .HasKey(x =>x.Id); 
    }
}
