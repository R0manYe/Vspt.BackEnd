using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Tiss.Pricing.Infrastructure.Database.EntityConfigurations;

internal class DislokaciaConfiguration : IEntityTypeConfiguration<Dislokacia>
{
	public void Configure(EntityTypeBuilder<Dislokacia> builder)
	{
		builder.ToTable("DISLOKACIA");

		builder.HasKey(x => x.ID);

		builder.Property(x => x.NPP_VAG)
			.HasPrecision(3);
	}
}
