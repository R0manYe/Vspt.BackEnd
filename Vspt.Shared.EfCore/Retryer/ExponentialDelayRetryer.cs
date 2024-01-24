using System;
using System.Threading;
using System.Threading.Tasks;

namespace Vspt.Box.EfCore.Retryer;

public sealed record ExponentialDelayRetryer : IRetryer
{
	public int? RandomSeed { get; init; }

	private int _maxRetryCount;
	public int MaxRetryCount
	{
		get => _maxRetryCount;
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(MaxRetryCount));
			}

			_maxRetryCount = value;
		}
	}

	private int _maxRetryDelayInMilliseconds;
	public int MaxRetryDelayInMilliseconds
	{
		get => _maxRetryDelayInMilliseconds;
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(MaxRetryDelayInMilliseconds));
			}

			_maxRetryDelayInMilliseconds = value;
		}
	}

	private double _exponentBase = 2;
	public double ExponentBase
	{
		get => _exponentBase;
		init
		{
			if (value <= 1)
			{
				throw new ArgumentOutOfRangeException(nameof(ExponentBase));
			}

			_exponentBase = value;
		}
	}

	private double _randomFactor;
	public double RandomFactor
	{
		get => _randomFactor;
		init
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(RandomFactor));
			}

			_randomFactor = value;
		}
	}

	public async Task<TResult> Execute<TResult>(
		IRetryerExecutionSettings settings,
		Func<IRetryer.OperationArgs, CancellationToken, Task<TResult>> operation,
		CancellationToken cancellationToken
	)
	{
		if (MaxRetryCount <= 0)
		{
			return await operation(new(0, 0), cancellationToken);
		}

		var random = RandomSeed == null ? new Random() : new Random(RandomSeed.Value);
		var maxRetryDelay = MaxRetryDelayInMilliseconds * 0.001;

		for (var attempt = 0; attempt < MaxRetryCount; attempt++)
		{
			try
			{
				return await operation(new(attempt, MaxRetryCount), cancellationToken);
			}
			catch (Exception e) when (settings.CanRetry(new(attempt, MaxRetryCount, e)))
			{
				// Same as https://github.com/dotnet/efcore/blob/v7.0.3/src/EFCore/Storage/ExecutionStrategy.cs#L431
				var delay = TimeSpan.FromSeconds(Math.Min(
					(Math.Pow(ExponentBase, attempt) - 1.0) * (1.0 + random.NextDouble() * RandomFactor),
					maxRetryDelay
				));

				settings.OnRetry(new(attempt, MaxRetryCount, delay, e));

				await Task.Delay(delay, cancellationToken);
			}
		}

		return await operation(new(MaxRetryCount, MaxRetryCount), cancellationToken);
	}
}
