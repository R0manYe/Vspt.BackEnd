using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface ISprFilialsRepository
    {
        Task<IReadOnlyList<SprFilials>> GetAllFilials(CancellationToken cancellationToken);
    }
}