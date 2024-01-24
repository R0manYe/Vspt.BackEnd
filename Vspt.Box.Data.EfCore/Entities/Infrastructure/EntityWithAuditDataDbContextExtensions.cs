using System;
using Microsoft.EntityFrameworkCore;
using Vspt.Box.Data.Entities;

namespace Vspt.Box.Data.EfCore.Entities.Infrastructure;

public static class EntityWithAuditDataDbContextExtensions
{
	public static void UpdateEntitiesWithAuditData(this DbContext context)
	{
		foreach (var entry in context.ChangeTracker.Entries())
		{
			if (!(entry.Entity is IEntityWithAuditData entity))
			{
				continue;
			}

			switch (entry.State)
			{
				case EntityState.Added:
					entity.AuditData.CreatedDate = DateTime.UtcNow;
					break;
				case EntityState.Modified:
					entity.AuditData.UpdatedDate = DateTime.UtcNow;
					break;
			}
		}
	}
}
