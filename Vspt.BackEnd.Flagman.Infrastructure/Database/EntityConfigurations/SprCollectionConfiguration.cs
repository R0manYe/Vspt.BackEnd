using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.Pricing.Infrastructure.Database.EntityConfigurations;

internal class SprCollectionConfiguration : IEntityTypeConfiguration<Spr_collection>
{
	public void Configure(EntityTypeBuilder<Spr_collection> builder)
	{
		builder.ToTable("SPR_COLLECTION");

		builder.HasKey(x => x.ID);		
		
	}
}
