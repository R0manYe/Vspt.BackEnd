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
    internal sealed class SubjectPersoneService : ISubjectPersoneService
    {
        private readonly IFlagmanApiClient _flagmanApiClient;
        public SubjectPersoneService (IFlagmanApiClient flagmanApiClient) 
        {
            _flagmanApiClient=flagmanApiClient;
        }
       
        public async Task<IReadOnlyList<Vspt_subject_personeDTO>> GetAllSubjectPersone()
        {
            var result=await _flagmanApiClient.GetVsptSubject();
            
            return result;
        }
       
    }
}
