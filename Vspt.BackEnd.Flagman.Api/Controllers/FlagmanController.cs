using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vspt.BackEnd.Flagman.Application.features;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Infrastructure.Database;


namespace Vspt.BackEnd.Flagman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlagmanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlagmanController(IMediator mediator)
        {
            _mediator = mediator;
        }  
      
        [HttpGet("dislokacia")]
        public async Task<List<Dislokacia>> GetDislokacia()
        {
            return await _mediator.Send(new GetDislokaciaHandlerRequest { Data = Unit.Value });
        }
        [HttpGet("vspt_subject_persone")]
        public async Task<List<Vspt_subject_persone>> GetVsptSubject()
        {
            return await _mediator.Send(new GetVsptSubjectPersoneHandlerRequest { Data = Unit.Value });
        }
    }
}
