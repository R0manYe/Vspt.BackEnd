using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore.Query.Internal;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.PublishModels.Dislokacia;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Infrastructure.Repositories;

internal sealed class SprOrgRepository : EntityRepository<FlagmanContext, Spr_org>, ISprOrgRepository
{
    public SprOrgRepository(FlagmanContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Spr_org>> GetSprOrg(IReadOnlyList<GetFilterIdResponseDTO> stations, CancellationToken cancellationToken)
    {
        return await _entityDbSet.Where(c=>stations.Select(x=> x.Id).Contains(c.IDSTATION)).ToListAsync(cancellationToken);      
    }
}


        
