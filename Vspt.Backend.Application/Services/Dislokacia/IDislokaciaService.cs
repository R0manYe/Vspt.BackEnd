using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Application.Services.SprOrg
{
    public interface IDislokaciaService
    {
        Task<IReadOnlyList<GetAllDislokacia>> GetDislokacia(CancellationToken cancellationToken);
        Task<IReadOnlyList<GetAllDislokacia>> GetDislokaciaFilterStations(string userId, CancellationToken cancellationToken);
    }
}
