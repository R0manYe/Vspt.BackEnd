using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.Box.Data.Entities;

namespace Vspt.Box.Data.EfCore.Entities.Infrastructure;

public static class EntityWithAuditDataTypeBuilderExtensions
{
	// TODO: Update to EfCore 8 and use  https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/plan#value-objects
	public static void ConfigureEntityAuditData<TEntity>(this EntityTypeBuilder<TEntity> builder)
		where TEntity : class, IEntityWithAuditData
	{
		builder
			.OwnsOne(
				x => x.AuditData,
				d =>
				{
					d.Property(x => x.CreatedDate).HasColumnName("created_date").IsRequired();
					d.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired();
					d.Property(x => x.UpdatedDate).HasColumnName("updated_date");
					d.Property(x => x.UpdatedBy).HasColumnName("updated_by");
				}
			)
			.Navigation(p => p.AuditData)
			.IsRequired();
	}
}
