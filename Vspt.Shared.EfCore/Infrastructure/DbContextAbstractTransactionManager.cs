using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vspt.Box.AbstractTransactions;
using Vspt.Box.EfCore.Retryer;

namespace Vspt.Box.EfCore.Infrastructure;

internal sealed class DbContextAbstractTransactionManager<TDbContext> : IAbstractTransactionManager, IRetryerExecutionSettings
	where TDbContext : DbContext
{
	private readonly IRetryer _retryer;
	private readonly ILogger<DbContextAbstractTransactionManager<TDbContext>> _logger;
	private readonly TDbContext _dbContext;

	public DbContextAbstractTransactionManager(
		IOptions<DbContextAbstractTransactionManagerOptions<TDbContext>> optionsAccessor,
		ILogger<DbContextAbstractTransactionManager<TDbContext>> logger,
		TDbContext dbContext
	)
	{
		var options = optionsAccessor.Value;
		_retryer = options.Retryer;

		_logger = logger;
		_dbContext = dbContext;
	}

	public Task<TResult> ExecuteInTransaction<TResult>(
		AbstractTransactionType transactionType,
		Func<CancellationToken, Task<TResult>> operation,
		CancellationToken cancellationToken
	)
	{
		return _retryer.Execute(this, async (args, cancellationToken) =>
		{
			if (transactionType == AbstractTransactionType.WithoutTransaction)
			{
				return await operation(cancellationToken);
			}

			var attempt = args.Attempt;

			await _dbContext.Database.OpenConnectionAsync(cancellationToken);

			try
			{
				TResult result;

				{
					await using var transaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.Serializable, cancellationToken);

					if (transactionType == AbstractTransactionType.SerializableReadOnly)
					{
						await _dbContext.Database.ExecuteSqlAsync(
							$"""
								SET TRANSACTION READ ONLY
								""",
							cancellationToken
						);
					}

					result = await operation(cancellationToken);

					await _dbContext.SaveChangesAsync(cancellationToken);

					await transaction.CommitAsync(cancellationToken);
				}

				if (attempt != 0)
				{
					_logger.LogWarning("Successful transaction after {Count} retries", attempt + 1);
				}

				return result;
			}
			finally
			{
				await _dbContext.Database.CloseConnectionAsync();
			}
		}, cancellationToken);
	}

	bool IRetryerExecutionSettings.CanRetry(IRetryerExecutionSettings.CanRetryArgs args)
	{
		return CanRetry(args.Exception);
	}

	private static bool CanRetry(Exception exception)
	{
		if (exception is DbException dbException)
		{
			return dbException.IsTransient;
		}

		if (exception.InnerException is DbException innerDbException)
		{
			return innerDbException.IsTransient;
		}

		return false;
	}

	void IRetryerExecutionSettings.OnRetry(IRetryerExecutionSettings.OnRetryArgs args)
	{
		_logger.LogWarning(
			"Retrying transaction, attempt {Attempt} of {MaxAttempt}, waiting {Delay}, error: '{ExceptionMessage}'",
			args.Attempt + 1,
			args.MaxAttempt,
			args.Delay,
			args.Exception.Message
		);
	}
}
