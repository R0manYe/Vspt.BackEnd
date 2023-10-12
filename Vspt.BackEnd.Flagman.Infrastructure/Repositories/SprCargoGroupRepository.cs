using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.Box.EfCore;

namespace Vspt.BackEnd.Flagman.Infrastructure.Repositories;

internal sealed class SprCargoGroupRepository : EntityRepository<FlagmanContext, Spr_cargo_group>, ISprCargoGroupRepository
{
    public SprCargoGroupRepository(FlagmanContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Spr_cargo_group>> GetSprCargoGroup(CancellationToken cancellationToken)
    {
        var result = await _entityDbSet.AsNoTracking().ToListAsync(cancellationToken);
        return result;
    }  
}


        
