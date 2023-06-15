using Microsoft.EntityFrameworkCore;
using Vspt.Box.EfCore.Retryer;

namespace Vspt.Box.EfCore.Infrastructure;

public class DbContextAbstractTransactionManagerOptions<TDbContext> where TDbContext : DbContext
{
	public IRetryer Retryer { get; set; } = new ExponentialDelayRetryer
	{
		MaxRetryCount = 10,
		MaxRetryDelayInMilliseconds = 10000,
		RandomFactor = 0.1,
	};
}
