using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.Box.EfCore;

namespace Vspt.BackEnd.Flagman.Infrastructure.Repositories
{
    internal sealed class VsptSubjectPersoneRepository : EntityRepository<FlagmanContext, Vspt_subject_persone>, IVsptSubjectPersoneRepository
    {
        public VsptSubjectPersoneRepository(FlagmanContext context) : base(context)
        {
        }

        public async Task<List<Vspt_subject_persone>> GetVsptSubjectPersone(CancellationToken cancellationToken)
        {
            return await _entityDbSet.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
