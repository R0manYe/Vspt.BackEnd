using System;
using System.Threading;
using System.Threading.Tasks;

namespace Vspt.Box.EfCore.Retryer;

public interface IRetryer
{
	Task<TResult> Execute<TResult>(
		IRetryerExecutionSettings settings,
		Func<OperationArgs, CancellationToken, Task<TResult>> operation,
		CancellationToken cancellationToken
	);
	readonly record struct OperationArgs(int Attempt, int MaxAttempt);
}
