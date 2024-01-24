using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vspt.Box.Data.Entities;
using Vspt.Box.EfCore;

namespace Vspt.Box.Data.EfCore.Entities;

public static class EntityDbSetExtensions
{
    public static async Task AddAndSave<TEntity>(
        this DbSet<TEntity> enityDbSet,
        TEntity entity,
        CancellationToken cancellationToken
    )
        where TEntity : class, IEntity
    {
        enityDbSet.Add(entity);
        var dbContext = enityDbSet.GetDbContext();
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public static async Task AddRangeAndSave<TEntity>(
        this DbSet<TEntity> entityDbSet,
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken
    )
        where TEntity : class, IEntity
    {
        entityDbSet.AddRange(entities);
        var dbContext = entityDbSet.GetDbContext();
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public static async Task UpdateAndSave<TEntity>(
        this DbSet<TEntity> entityDbSet,
        TEntity entity,
        CancellationToken cancellationToken
    )
        where TEntity : class, IEntity
    {
        entityDbSet.Update(entity);
        var dbContext = entityDbSet.GetDbContext();
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public static async Task UpdateRangeAndSave<TEntity>(
        this DbSet<TEntity> entityDbSet,
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken
    )
        where TEntity : class, IEntity
    {
        entityDbSet.UpdateRange(entities);
        var dbContext = entityDbSet.GetDbContext();
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public static async Task AddOrUpdateBatch<TEntity>(
        this DbSet<TEntity> entityDbSet,
        IReadOnlyList<TEntity>? itemsToAdd,
        IReadOnlyList<TEntity>? itemsToUpdate,
        CancellationToken cancellationToken
    )
        where TEntity : class, IEntity
    {
        var hasChanges = false;

        if (itemsToAdd != null && itemsToAdd.Count > 0)
        {
            entityDbSet.AddRange(itemsToAdd);
            hasChanges = true;
        }

        if (itemsToUpdate != null && itemsToUpdate.Count > 0)
        {
            entityDbSet.UpdateRange(itemsToUpdate);
            hasChanges = true;
        }

        if (!hasChanges)
        {
            return;
        }

        var dbContext = entityDbSet.GetDbContext();
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public static async Task RemoveAndSave<TEntity>(
        this DbSet<TEntity> entityDbSet,
        TEntity entity,
        CancellationToken cancellationToken
    )
        where TEntity : class, IEntity
    {
        entityDbSet.Remove(entity);
        var dbContext = entityDbSet.GetDbContext();
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
