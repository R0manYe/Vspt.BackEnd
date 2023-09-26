using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class SprDistricsConfiguration : IEntityTypeConfiguration<SprDistrict>
{
    public void Configure(EntityTypeBuilder<SprDistrict> builder)
    {
        builder
            .ToTable("SprDistricts");

        builder
            .HasKey(x => x.Id);      

        builder
            .HasOne(x => x.SprFilial)
            .WithMany()
            .HasForeignKey(x => x.Bu_id);
       
        builder
          .Property(x => x.Id)
          .IsRequired()
          .HasMaxLength(12);

    }
}
