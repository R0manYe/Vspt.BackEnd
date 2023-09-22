using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class SprFilialsConfiguration : IEntityTypeConfiguration<SprFilials>
{
    public void Configure(EntityTypeBuilder<SprFilials> builder)
    {
        builder
            .ToTable("SprFilials");

        builder
            .HasKey(x =>x.Id); 
    }
}
