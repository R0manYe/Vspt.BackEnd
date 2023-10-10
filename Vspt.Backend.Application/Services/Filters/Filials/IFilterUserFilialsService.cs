using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Application.Services.Filters.Filials
{
    public interface IFilterUserFilialsService
    {
       Task<IReadOnlyList<GetFilterResponseDTO>> GetIdNameFilials(string Username, CancellationToken cancellationToken);
       Task<IReadOnlyList<GetFilterIdResponseDTO>> GetIdFilials(string username, CancellationToken cancellationToken);       
    }
}
