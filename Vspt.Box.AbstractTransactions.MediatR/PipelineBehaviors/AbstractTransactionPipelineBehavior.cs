using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vspt.Box.AbstractTransactions.MediatR.MarkerRequestInterfaces;

namespace Vspt.Box.AbstractTransactions.MediatR.PipelineBehaviors;

public sealed class AbstractTransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly IAbstractTransactionManager _abstractTransactionManager;

	public AbstractTransactionPipelineBehavior(
		IAbstractTransactionManager abstractTransactionManager
	)
	{
		_abstractTransactionManager = abstractTransactionManager;
	}

	public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
	{
		var transactionType = GetTransactionType(request) ?? AbstractTransactionType.WithoutTransaction;

		return await _abstractTransactionManager.ExecuteInTransaction(transactionType, async cancellationToken =>
		{
			return await next();
		});
	}

	private static AbstractTransactionType? GetTransactionType(TRequest request)
	{
		Type? currentMarkerType = null;
		AbstractTransactionType? currentType = null;

		SetType<IWithoutTransaction>(request, ref currentMarkerType, ref currentType, AbstractTransactionType.WithoutTransaction);
		SetType<IWithWritableTransaction>(request, ref currentMarkerType, ref currentType, AbstractTransactionType.Serializable);
		SetType<IWithReadOnlyTransaction>(request, ref currentMarkerType, ref currentType, AbstractTransactionType.SerializableReadOnly);

		static void SetType<TMarker>(
			TRequest request,
			ref Type? currentMarkerType,
			ref AbstractTransactionType? currentTransactionType,
			AbstractTransactionType type
		)
		{
			if (request is not TMarker)
			{
				return;
			}

			if (currentTransactionType != null)
			{
				throw new InvalidOperationException(
					$"Can not use multiple marker interfaces on same type. {typeof(TRequest)} has {currentMarkerType} and {typeof(TMarker)}"
				);
			}

			currentTransactionType = type;
			currentMarkerType = typeof(TMarker);
		}

		return currentType;
	}
}

