using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contracts.Pagination;
using Vspt.BackEnd.Flagman.ApiClients;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.Services.SprOrg
{
    internal sealed class SprCargoService : ISprCargoService
    {
        private readonly IFlagmanApiClient _flagmanApiClient;
        public SprCargoService(IFlagmanApiClient flagmanApiClient)
        {
            _flagmanApiClient = flagmanApiClient;
        }

        public async Task<IReadOnlyList<GetFilterIdNameDTO>> GetSprCargo(CancellationToken cancellationToken)
        {
            var result = await _flagmanApiClient.GetSprCargo(cancellationToken);

            return result;
        }

    }
}
