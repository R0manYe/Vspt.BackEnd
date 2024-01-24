using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.Pricing.Infrastructure.Database.EntityConfigurations;

internal class SprCargoGroupConfiguration : IEntityTypeConfiguration<Spr_cargo_group>
{
	public void Configure(EntityTypeBuilder<Spr_cargo_group> builder)
	{
		builder.ToTable("SPR_CARGO_GROUP");

		builder.HasKey(x => x.ID);
	}
}
