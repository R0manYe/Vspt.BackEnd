using System;

namespace Vspt.Box.EfCore.Retryer;

public interface IRetryerExecutionSettings
{
	bool CanRetry(CanRetryArgs args);
	public readonly record struct CanRetryArgs(int Attempt, int MaxAttempt, Exception Exception);

	void OnRetry(OnRetryArgs args);
	public readonly record struct OnRetryArgs(int Attempt, int MaxAttempt, TimeSpan Delay, Exception Exception);
}
