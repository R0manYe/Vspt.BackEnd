using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Tiss.Pricing.Infrastructure.Database.EntityConfigurations;

internal class GetAllConfiguration : IEntityTypeConfiguration<GetAllDislokacia>
{
	public void Configure(EntityTypeBuilder<GetAllDislokacia> builder)
	{
		builder.ToTable("GETALLDISLOKACIA");

		builder.HasKey(x => x.ID);

		builder.Property(x => x.NPP_VAG)
			.HasPrecision(3);
		
		//builder.HasOne(x=>x.Spr_Etran_Railways)
		//	.WithMany()
  //          .HasForeignKey(x => x.DOR_RASCH)
  //          .OnDelete(DeleteBehavior.Restrict);
    }
}
