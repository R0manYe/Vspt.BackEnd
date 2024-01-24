using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Domain.Contract
{
    public interface IDislokaciaRepository
    {
        Task<List<GetAllDislokacia>> GetDislokacia(CancellationToken cancellationToken);
        Task<List<GetAllDislokacia>> GetDislokaciaFilter(IReadOnlyList<GetFilterIdRequestDTO> stations,CancellationToken cancellationToken);
    }
}