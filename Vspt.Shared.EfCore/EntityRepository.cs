using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Vspt.Box.EfCore;

[SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "`protected readonly` field is fine")]
public abstract class EntityRepository<TDbContext, TEntity>
    where TDbContext : DbContext
    where TEntity : class
{
    protected readonly TDbContext _dbContext;
    protected readonly DbSet<TEntity> _entityDbSet;

    protected EntityRepository(TDbContext context)
    {
        _dbContext = context;
        _entityDbSet = context.Set<TEntity>();
    }
}
