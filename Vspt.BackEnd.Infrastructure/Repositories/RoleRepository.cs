using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class RoleRepository : EntityRepository<PgContext, IdentityRoles>, IRolesRepository
{
    public RoleRepository(PgContext context) : base(context)
    {
    }

    public Task AddRoles(IdentityRoles entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.AddAndSave(entity, cancellationToken);
    }

    public async Task DeleteRoles(byte id, CancellationToken cancellationToken)
    {
        var item = await _entityDbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item != null)
        {
            await _entityDbSet.RemoveAndSave(item, cancellationToken);
        }
    }

    public Task UpdateRoles(IdentityRoles entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.UpdateAndSave(entity, cancellationToken);
    }

    public async Task<IReadOnlyList<IdentityRoles>> GetReadRoles(CancellationToken cancellationToken)
    {
        return await _entityDbSet.ToListAsync(cancellationToken);
    }


}
