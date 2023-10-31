using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class SprSvodRepository : EntityRepository<PgContext, SprSvod>, ISprSvodRepository
{
    public SprSvodRepository(PgContext context) : base(context)
    {
    }   

    public async Task<IReadOnlyList<SprSvod>> GetSprSvod(CancellationToken cancellationToken)
    {
        return await _entityDbSet.ToListAsync(cancellationToken);
    }
}

   
