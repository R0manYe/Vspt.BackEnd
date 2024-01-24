using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vspt.Box.EfCore.Infrastructure;

public interface IEntityInterfaceConfiguration<TEntityInterface>
	where TEntityInterface : class
{
	void Configure<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : class, TEntityInterface;
}
