using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class VsptSubjectPersoneConfiguration : IEntityTypeConfiguration<Vspt_subject_persone>
{
    public void Configure(EntityTypeBuilder<Vspt_subject_persone> builder)
    {
        builder
            .ToTable("VsptSubjectPersones");

        builder
            .HasKey(x =>x.ID);      

    }
}
