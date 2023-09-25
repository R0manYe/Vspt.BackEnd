using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.PublishModels.Dislokacia;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.Box.EfCore;

namespace Vspt.BackEnd.Flagman.Infrastructure.Repositories;

internal sealed class SprOrgRepository : EntityRepository<FlagmanContext, Spr_org>, ISprOrgRepository
{
    public SprOrgRepository(FlagmanContext context) : base(context)
    {
    }

    public async Task<List<Spr_org>> GetSprOrg(CancellationToken cancellationToken)
    {

        var result =await _entityDbSet.AsNoTracking().ToListAsync(cancellationToken);
        return result;

    }
}


        
