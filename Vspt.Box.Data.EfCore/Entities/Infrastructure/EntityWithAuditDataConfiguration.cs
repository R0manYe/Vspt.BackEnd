using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vspt.Box.Data.Entities;
using Vspt.Box.EfCore.Infrastructure;

namespace Vspt.Box.Data.EfCore.Entities.Infrastructure;

public sealed class EntityWithAuditDataConfiguration : IEntityInterfaceConfiguration<IEntityWithAuditData>
{
	void IEntityInterfaceConfiguration<IEntityWithAuditData>.Configure<TEntity>(EntityTypeBuilder<TEntity> builder)
	{
		builder.ConfigureEntityAuditData();
	}
}
