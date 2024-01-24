using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.Services.Filters.Filials
{
    public interface IFilterUserFilialsService
    {
       Task<IReadOnlyList<GetFilterIdLongNameDTO>> GetIdNameFilials(uint Username, CancellationToken cancellationToken);
       Task<IReadOnlyList<GetFilterIdResponseDTO>> GetIdFilials(uint username, CancellationToken cancellationToken);       
    }
}
