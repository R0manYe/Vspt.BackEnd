using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Flagman.Domain.Contract
{
    public interface ISprCollectionRepository
    {

        Task<List<Spr_collection>> ISprCollectionRepository(CancellationToken cancellationToken);
    }
}