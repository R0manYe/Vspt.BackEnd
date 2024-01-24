using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Role;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class SprFilialRepository : EntityRepository<PgContext, SprFilials>, ISprFilialsRepository
{
    public SprFilialRepository(PgContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<SprFilials>> GetAllFilials(CancellationToken cancellationToken)
    {
        return await _entityDbSet.ToListAsync(cancellationToken);
    }

   
}
