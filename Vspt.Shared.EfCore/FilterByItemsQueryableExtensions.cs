using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace Vspt.Box.EfCore;

public static class FilterByItemsQueryableExtensions
{
	// From https://stackoverflow.com/questions/67666649/lambda-linq-with-contains-criteria-for-multiple-keywords/67666993#67666993
	public static IQueryable<T> FilterByItems<T, TItem>(
		this IQueryable<T> query, IEnumerable<TItem> items,
		Expression<Func<T, TItem, bool>> filterPattern, bool isOr
	)
	{
		Expression? predicate = null;
		foreach (var item in items)
		{
			var itemExpr = Expression.Constant(item);
			var itemCondition = ExpressionReplacer.Replace(filterPattern.Body, filterPattern.Parameters[1], itemExpr);

			predicate = predicate == null
				? itemCondition
				: Expression.MakeBinary(isOr ? ExpressionType.OrElse : ExpressionType.AndAlso, predicate,
					itemCondition);
		}

		predicate ??= Expression.Constant(false);
		var filterLambda = Expression.Lambda<Func<T, bool>>(predicate, filterPattern.Parameters[0]);

		return query.Where(filterLambda);
	}

	private sealed class ExpressionReplacer : ExpressionVisitor
	{
		private readonly IDictionary<Expression, Expression> _replaceMap;

		public ExpressionReplacer(IDictionary<Expression, Expression> replaceMap)
		{
			_replaceMap = replaceMap ?? throw new ArgumentNullException(nameof(replaceMap));
		}

		[return: NotNullIfNotNull(nameof(exp))]
		public override Expression? Visit(Expression? exp)
		{
			if (exp != null && _replaceMap.TryGetValue(exp, out var replacement))
			{
				return replacement;
			}

			return base.Visit(exp);
		}

		public static Expression Replace(Expression expr, Expression toReplace, Expression toExpr)
		{
			return new ExpressionReplacer(new Dictionary<Expression, Expression> { { toReplace, toExpr } }).Visit(expr);
		}

		public static Expression Replace(Expression expr, IDictionary<Expression, Expression> replaceMap)
		{
			return new ExpressionReplacer(replaceMap).Visit(expr);
		}

		public static Expression GetBody(LambdaExpression lambda, params Expression[] toReplace)
		{
			if (lambda.Parameters.Count != toReplace.Length)
			{
				throw new InvalidOperationException();
			}

			return new ExpressionReplacer(Enumerable.Range(0, lambda.Parameters.Count)
				.ToDictionary(i => (Expression)lambda.Parameters[i], i => toReplace[i])).Visit(lambda.Body);
		}
	}
}
