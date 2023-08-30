using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Flagman.ApiClient
{
    public partial interface IFlagmanSubjectPersoneApiClient
    {
        [HttpGet("/v1/flagman/subjectpersone")]
        Task<IReadOnlyList<Vspt_subject_persone>> GetSubjectPersone([Body] CancellationToken cancellationToken = default);
    }
}
