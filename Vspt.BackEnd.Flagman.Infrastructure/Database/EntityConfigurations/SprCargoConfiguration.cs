using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.Pricing.Infrastructure.Database.EntityConfigurations;

internal class SprCargoConfiguration : IEntityTypeConfiguration<Spr_cargo>
{
	public void Configure(EntityTypeBuilder<Spr_cargo> builder)
	{
		builder.ToTable("SPR_CARGO");

		builder.HasKey(x => x.ID);
       
    }
}
