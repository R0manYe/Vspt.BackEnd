using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;

namespace Vspt.BackEnd.Flagman.Infrastructure.Repositories;

internal sealed class DislokaciaRepository : EntityRepository<FlagmanContext, Dislokacia>, IDislokaciaRepository
{
    public DislokaciaRepository(FlagmanContext context) : base(context)
    {
    }

   

    public async Task<List<Dislokacia>> GetDislokacia(CancellationToken cancellationToken)
    {
        return await _entityDbSet.AsNoTracking().ToListAsync(cancellationToken);
    }


}
