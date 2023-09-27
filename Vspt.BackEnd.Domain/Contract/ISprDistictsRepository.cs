using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Role;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface ISprDistrictsRepository
    {
       Task<IReadOnlyList<SprDistrict>> GetAllDistricts(CancellationToken cancellationToken);
      
    }
}