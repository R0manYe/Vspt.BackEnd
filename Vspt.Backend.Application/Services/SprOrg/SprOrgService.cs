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

namespace Vspt.BackEnd.Application.Services.SubjectPersone
{
    internal sealed class SprOrgService : ISprOrgService
    {
        private readonly IFlagmanSprOrgApiClient _flagmanSprOrgApiClient;
        public SprOrgService (IFlagmanSprOrgApiClient flagmanSprOrgApiClient) 
        {
            _flagmanSprOrgApiClient =flagmanSprOrgApiClient;
        }
       
        public async Task<IReadOnlyList<Spr_org>> GetSprOrg()
        {
            var result=await _flagmanSprOrgApiClient.GetSprOrg();
            
            return result;
        }
       
    }
}
