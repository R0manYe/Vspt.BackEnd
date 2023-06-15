using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vspt.Box.Data.Entities;

namespace Vspt.Box.Data.EfCore.Entities;

public static class EntityWithIdAndExternalIdQueryableExtensions
{
	public static async Task<TEntity?> GetEntityByExternalId<TEntity>(
		this IQueryable<TEntity> source,
		string externalId,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId, IEntityWithExternalId
	{
		return await source.GetEntityByExternalIdCore(externalId, QueryTrackingBehavior.NoTracking, cancellationToken);
	}

	public static async Task<TEntity?> GetTrackedEntityByExternalId<TEntity>(
		this IQueryable<TEntity> source,
		string externalId,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId, IEntityWithExternalId
	{
		return await source.GetEntityByExternalIdCore(externalId, QueryTrackingBehavior.TrackAll, cancellationToken);
	}

	private static async Task<TEntity?> GetEntityByExternalIdCore<TEntity>(
		this IQueryable<TEntity> source,
		string externalId,
		QueryTrackingBehavior trackingBehavior,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId, IEntityWithExternalId
	{
		if (string.IsNullOrEmpty(externalId))
		{
			return null;
		}

		return await source
			.Where(x => x.ExternalId == externalId)
			.AsTracking(trackingBehavior)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public static async Task<Guid?> GetIdByExternalId<TEntity>(
		this IQueryable<TEntity> source,
		string externalId,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId, IEntityWithExternalId
	{
		if (string.IsNullOrEmpty(externalId))
		{
			return null;
		}

		var entity = await source
			.Where(x => x.ExternalId == externalId)
			.Select(x => new { x.Id })
			.FirstOrDefaultAsync(cancellationToken);

		return entity?.Id;
	}

	public static async Task<IReadOnlyList<TEntity>> GetEntitiesByExternalIds<TEntity>(
		this IQueryable<TEntity> source,
		IEnumerable<string> externalIds,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId, IEntityWithExternalId
	{
		return await source.GetEntitiesByExternalIdsCore(externalIds, QueryTrackingBehavior.NoTracking, cancellationToken);
	}

	public static async Task<IReadOnlyList<TEntity>> GetTrackedEntitiesByExternalIds<TEntity>(
		this IQueryable<TEntity> source,
		IEnumerable<string> externalIds,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId, IEntityWithExternalId
	{
		return await source.GetEntitiesByExternalIdsCore(externalIds, QueryTrackingBehavior.TrackAll, cancellationToken);
	}

	private static async Task<IReadOnlyList<TEntity>> GetEntitiesByExternalIdsCore<TEntity>(
		this IQueryable<TEntity> source,
		IEnumerable<string> externalIds,
		QueryTrackingBehavior trackingBehavior,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId, IEntityWithExternalId
	{
		if (externalIds == null)
		{
			return Array.Empty<TEntity>();
		}

		var externalIdList = externalIds
			.Where(externalId => !string.IsNullOrEmpty(externalId))
			.ToList();

		if (externalIdList.Count == 0)
		{
			return Array.Empty<TEntity>();
		}

		return await source
			.Where(x => externalIdList.Contains(x.ExternalId))
			.AsTracking(trackingBehavior)
			.ToListAsync(cancellationToken);
	}

	public static async Task<IReadOnlyDictionary<string, Guid>> GetIdByExternalIdMapping<TEntity>(
		this IQueryable<TEntity> source,
		IEnumerable<string> externalIds,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId, IEntityWithExternalId
	{
		if (externalIds == null)
		{
			return ImmutableDictionary<string, Guid>.Empty;
		}

		var externalIdList = externalIds
			.Where(externalId => !string.IsNullOrEmpty(externalId))
			.ToList();

		if (externalIdList.Count == 0)
		{
			return ImmutableDictionary<string, Guid>.Empty;
		}

		return await source
			.Where(x => externalIdList.Contains(x.ExternalId))
			.Select(x => new { x.Id, x.ExternalId })
			.ToDictionaryAsync(x => x.ExternalId, y => y.Id, cancellationToken);
	}
}
