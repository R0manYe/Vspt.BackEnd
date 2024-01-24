using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Application.Services.SprOrg
{
    public interface IDislokaciaService
    {
        Task<IReadOnlyList<GetAllDislokacia>> GetDislokacia(CancellationToken cancellationToken);
        Task<IReadOnlyList<GetAllDislokacia>> GetDislokaciaFilterStations(uint userId, CancellationToken cancellationToken);
    }
}
