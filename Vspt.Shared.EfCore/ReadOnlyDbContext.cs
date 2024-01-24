using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Vspt.Box.EfCore;

public sealed class ReadOnlyDbContext<TDbContext>
	where TDbContext : DbContext
{
	private readonly TDbContext _dbContext;

	public ReadOnlyDbContext(TDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public IQueryable<TEntity> Set<TEntity>()
		where TEntity : class
	{
		return _dbContext.Set<TEntity>().AsNoTracking();
	}
}
