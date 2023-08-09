using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class ClaimRepository : EntityRepository<PgContext, IdentityClaims>, IClaimsRepository
{
    public ClaimRepository(PgContext context) : base(context)
    {
    }

    public Task AddClaim(IdentityClaims entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.AddAndSave(entity, cancellationToken);
    }

    public async Task DeleteClaim(Guid id, CancellationToken cancellationToken)
    {
        var item = await _entityDbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item != null)
        {
            await _entityDbSet.RemoveAndSave(item, cancellationToken);
        }
    }

    public Task UpdateClaim(IdentityClaims entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.UpdateAndSave(entity, cancellationToken);
    }

    public async Task<IReadOnlyList<IdentityClaims>> GetReadClaims(CancellationToken cancellationToken)
    {
        return await _entityDbSet.ToListAsync(cancellationToken);
    }
}

   
