using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

internal sealed class FilialsStationsDistrictssConfiguration : IEntityTypeConfiguration<FilialsStationsDistricts>
{
    public void Configure(EntityTypeBuilder<FilialsStationsDistricts> builder)
    {
        builder
            .ToTable("FilialsStationsDistricts");
        builder.HasNoKey();
       

        builder
           .HasOne(x => x.Districts)
           .WithMany()
           .HasForeignKey(x => x.DistrictId);

        builder
          .HasOne(x => x.Filials)
          .WithMany()
          .HasForeignKey(x => x.BuId);
    }
}
