using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vspt.Box.Data.Entities;
using Vspt.Box.EfCore;

namespace Vspt.Box.Data.EfCore.Entities;

public static class EntityWithIdQueryableExtensions
{
	public static async Task<TEntity?> GetEntityById<TEntity>(
		this IQueryable<TEntity> source,
		Guid id,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId
	{
		return await source.GetEntityByIdCore(id, QueryTrackingBehavior.NoTracking, cancellationToken);
	}

	public static async Task<TEntity?> GetTrackedEntityById<TEntity>(
		this IQueryable<TEntity> source,
		Guid id,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId
	{
		return await source.GetEntityByIdCore(id, QueryTrackingBehavior.TrackAll, cancellationToken);
	}

	private static async Task<TEntity?> GetEntityByIdCore<TEntity>(
		this IQueryable<TEntity> source,
		Guid id,
		QueryTrackingBehavior trackingBehavior,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId
	{
		return await source
			.Where(x => x.Id == id)
			.AsTracking(trackingBehavior)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public static async Task<IReadOnlyList<TEntity>> GetEntitiesByIds<TEntity>(
		this IQueryable<TEntity> source,
		IEnumerable<Guid>? ids,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId
	{
		return await source.GetEntitiesByIdsCore(ids, QueryTrackingBehavior.NoTracking, cancellationToken);
	}

	public static async Task<IReadOnlyList<TEntity>> GetTrackedEntitiesByIds<TEntity>(
		this IQueryable<TEntity> source,
		IEnumerable<Guid>? externalIds,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId
	{
		return await source.GetEntitiesByIdsCore(externalIds, QueryTrackingBehavior.TrackAll, cancellationToken);
	}

	private static async Task<IReadOnlyList<TEntity>> GetEntitiesByIdsCore<TEntity>(
		this IQueryable<TEntity> source,
		IEnumerable<Guid>? ids,
		QueryTrackingBehavior trackingBehavior,
		CancellationToken cancellationToken
	)
		where TEntity : class, IEntityWithId
	{
		if (ids == null)
		{
			return Array.Empty<TEntity>();
		}

		var idList = ids.ToList();

		if (idList.Count == 0)
		{
			return Array.Empty<TEntity>();
		}

		return await source
			.Where(x => idList.Contains(x.Id))
			.AsTracking(trackingBehavior)
			.ToListAsync(cancellationToken);
	}

	public static async Task<Dictionary<Guid, bool>> CheckEntitiesExistByIds<TEntity>(this IQueryable<TEntity> source,
		IReadOnlyList<Guid> ids,
		CancellationToken cancellationToken)
		where TEntity : class, IEntityWithId
	{
		var existEntityIds = (await source
			.Where(x => ids.AsEfList().Contains(x.Id)).Select(s => s.Id).ToListAsync(cancellationToken))
			.ToHashSet();

		return ids.ToDictionary(k => k, existEntityIds.Contains);
	}
}
