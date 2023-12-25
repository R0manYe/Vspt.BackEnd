using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Domain.Contract
{
    public interface ISprOrgRepository
    {
        Task<IReadOnlyList<Spr_org>> GetSprOrg(IReadOnlyList<GetFilterIdResponseDTO> stations, CancellationToken cancellationToken);
    }
}