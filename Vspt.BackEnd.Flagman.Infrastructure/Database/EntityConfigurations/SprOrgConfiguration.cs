using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.Pricing.Infrastructure.Database.EntityConfigurations;

internal class SprOrgConfiguration : IEntityTypeConfiguration<Spr_org>
{
	public void Configure(EntityTypeBuilder<Spr_org> builder)
	{
		builder.ToTable("SPR_ORG");

		builder.HasKey(x => x.ID);		
	}
}
