using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface IIdentityClaimsRepository
    {
        Task AddIdentityClaim(IdentityClaims entity, CancellationToken cancellationToken);      
        Task<IReadOnlyList<GetFilterIdRequestDTO>> GetFilterClaim(uint username,byte Filtr, CancellationToken cancellationToken);       
        Task UpdateClaim(IdentityClaims entity, CancellationToken cancellationToken);
        Task DeleteClaim(Guid Id, CancellationToken cancellationToken);
        Task<IReadOnlyList<IdentityClaims>> GetReadClaims(CancellationToken cancellationToken);
    }
}