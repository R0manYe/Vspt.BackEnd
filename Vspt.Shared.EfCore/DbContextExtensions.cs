using Microsoft.EntityFrameworkCore;

namespace Vspt.Box.EfCore;

public static class DbContextExtensions
{
	public static ReadOnlyDbContext<TDbContext> AsReadOnly<TDbContext>(this TDbContext dbContext)
		where TDbContext : DbContext
	{
		return new ReadOnlyDbContext<TDbContext>(dbContext);
	}
}
