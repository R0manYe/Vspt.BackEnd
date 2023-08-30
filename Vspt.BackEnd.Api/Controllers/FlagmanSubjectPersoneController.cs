using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.Services.SubjectPersone;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Flagman.DTO.VsptSubjectPersone;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("v{version:apiVersion}/subjectpersone")]
    [ApiController]
    [ApiVersionNeutral]

    public class FlagmanSubjectPersoneController : ControllerBase
    {
        private readonly ISubjectPersoneService _subjectPersoneService;
        [HttpGet("count")]
        public Task<IReadOnlyList<Vspt_subject_persone>> GetSuppliersCount()
        {
            return _subjectPersoneService.GetSubjectPersone();
        }

    }
}
