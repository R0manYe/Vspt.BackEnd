using System;
using System.Threading;
using System.Threading.Tasks;

namespace Vspt.Box.AbstractTransactions;

public static class AbstractTransactionManagerExtensions
{
	public static async Task ExecuteInTransaction(
		this IAbstractTransactionManager abstractTransactionManager,
		AbstractTransactionType transactionType,
		Func<CancellationToken, Task> operation,
		CancellationToken cancellationToken = default
	)
	{
		_ = await abstractTransactionManager.ExecuteInTransaction(transactionType, async cancellationToken =>
		{
			await operation(cancellationToken);
			return 0;
		}, cancellationToken);
	}

	public static Task<TResult> ExecuteInTransaction<TResult>(
		this IAbstractTransactionManager abstractTransactionManager,
		Func<CancellationToken, Task<TResult>> operation,
		CancellationToken cancellationToken = default
	)
	{
		return abstractTransactionManager.ExecuteInTransaction(AbstractTransactionType.Serializable, operation, cancellationToken);
	}

	public static Task ExecuteInTransaction(
		this IAbstractTransactionManager abstractTransactionManager,
		Func<CancellationToken, Task> operation,
		CancellationToken cancellationToken = default
	)
	{
		return abstractTransactionManager.ExecuteInTransaction(AbstractTransactionType.Serializable, operation, cancellationToken);
	}
}
