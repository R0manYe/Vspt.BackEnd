using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.Pricing.Infrastructure.Database.EntityConfigurations;

internal class VsptSubjectPersoneConfiguration : IEntityTypeConfiguration<Vspt_subject_persone>
{
	public void Configure(EntityTypeBuilder<Vspt_subject_persone> builder)
	{
		builder.ToTable("VSPT_SUBJECT_PERSONE");

		builder.HasKey(x => x.ID);		
	}
}
