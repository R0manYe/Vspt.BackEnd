using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Domain.Contract;

public interface IFilialsStationsDistrictsRepository
{  
    Task<IReadOnlyList<GetFilterIdResponseDTO>> GetFilialStationFull(IReadOnlyList<GetFilterIdResponseDTO> existingFilials, CancellationToken cancellationToken);
}