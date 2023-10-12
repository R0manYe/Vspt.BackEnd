using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.PublishModels.Dislokacia;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Infrastructure.Repositories;

internal sealed class DislokaciaRepository : EntityRepository<FlagmanContext, GetAllDislokacia>, IDislokaciaRepository
{
    public DislokaciaRepository(FlagmanContext context) : base(context)
    {
    }

    public async Task<List<GetAllDislokacia>> GetDislokacia(CancellationToken cancellationToken)
    {
        return await _entityDbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<List<GetAllDislokacia>> GetDislokaciaFilter(IReadOnlyList<GetFilterIdRequestDTO> stations, CancellationToken cancellationToken)
    {
        return await _entityDbSet.Where(c =>stations.Select(x=>x.Id).Contains(c.STAN_NAZN)).ToListAsync();
    }
}


        
