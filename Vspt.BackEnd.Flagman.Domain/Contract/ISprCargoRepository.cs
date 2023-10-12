using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Domain.Contract
{
    public interface ISprCargoRepository
    {
        Task<IReadOnlyList<Spr_cargo>> GetSprCargoFull(CancellationToken cancellationToken);
        Task<IReadOnlyList<GetFilterIdNameDTO>> GetSprCargo(CancellationToken cancellationToken);
    }
}