using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.Services.SubjectPersone;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("v1/subjectpersone")]
    [ApiController]
    [ApiVersionNeutral]    

    public class FlagmanSubjectPersoneController : ControllerBase
    {
        private readonly ISubjectPersoneService _subjectPersoneService;
       
        [HttpGet("count")]
        public Task<List<Vspt_subject_persone>> GetSubjectCount()
        {
            return _subjectPersoneService.GetSubjectPersone();
        }

    }
}
