using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Flagman.Domain.Contract
{
    public interface IDislokaciaRepository
    {

        Task<List<Dislokacia>> GetDislokacia(CancellationToken cancellationToken);
    }
}