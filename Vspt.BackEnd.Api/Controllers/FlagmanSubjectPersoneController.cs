using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.Services.SubjectPersone;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("v1/vspt-subjects/")]
    [ApiController]
    [ApiVersionNeutral]    

    public class FlagmanSubjectPersoneController : ControllerBase
    {
        private readonly ISubjectPersoneService _subjectPersoneService;

        public FlagmanSubjectPersoneController(ISubjectPersoneService subjectPersoneService)
        {
            _subjectPersoneService = subjectPersoneService;
        }

        [HttpPost("list")]
        public Task<IReadOnlyList<Vspt_subject_personeDTO>> GetAllUsersSubjectPersone()
        {
            return _subjectPersoneService.GetAllSubjectPersone();
           
        }
        //[HttpPost("getUser")]
        //public Task<IReadOnlyList<Vspt_subject_personeDTO>> GetUserSubjectRepsone(string search)
        //{
        //    return _subjectPersoneService.GetUserSubjectPersone(search);

        //}

    }
}
