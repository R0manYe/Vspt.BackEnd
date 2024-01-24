using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.Pricing.Infrastructure.Database.EntityConfigurations;

internal class DislokaciaConfiguration : IEntityTypeConfiguration<Dislokacia>
{
	public void Configure(EntityTypeBuilder<Dislokacia> builder)
	{
		builder.ToTable("DISLOKACIA");

		builder.HasKey(x => x.ID);

		builder.Property(x => x.NPP_VAG)
			.HasPrecision(3);
		
		//builder.HasOne(x=>x.Spr_Etran_Railways)
		//	.WithMany()
  //          .HasForeignKey(x => x.DOR_RASCH)
  //          .OnDelete(DeleteBehavior.Restrict);
    }
}
