using System;
using System.Threading;
using System.Threading.Tasks;

namespace Vspt.Box.AbstractTransactions;

public interface IAbstractTransactionManager
{
	Task<TResult> ExecuteInTransaction<TResult>(
		AbstractTransactionType transactionType,
		Func<CancellationToken, Task<TResult>> operation,
		CancellationToken cancellationToken = default
	);
}
