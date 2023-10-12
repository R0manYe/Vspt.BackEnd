using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vspt.BackEnd.Flagman.Application.features;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.PublishModels.Dislokacia;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

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
        public async Task<List<GetAllDislokacia>> GetDislokacia()
        {
            return await _mediator.Send(new GetDislokaciaHandlerRequest { Data = Unit.Value });
        }
        [HttpPost("dislokaciaFiltrStation")]
        public async Task<List<GetAllDislokacia>> GetDislokaciaFiltrStation(IReadOnlyList<GetFilterIdRequestDTO> stations, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetDislokaciaFilterStationHandlerRequest { Data = stations });
        }
        [HttpGet("vspt_subject_persone")]
        public async Task<List<Vspt_subject_persone>> GetVsptSubject()
        {
            return await _mediator.Send(new GetVsptSubjectPersoneHandlerRequest { Data = Unit.Value });
        }
        [HttpGet("vspt_spr_org")]
        public async Task<List<Spr_org>> GetVsptOrg()
        {
            return await _mediator.Send(new GetSprOrgHandlerRequest { Data = Unit.Value });
        }
        [HttpGet("/cargo/full")]
        public async Task<IReadOnlyList<Spr_cargo>> GetVsptCargoFull()
        {
            return await _mediator.Send(new GetSprCargoFullHandlerRequest { Data = Unit.Value });
        }
        [HttpGet("cargo/vspt_spr_cargo")]
        public async Task<IReadOnlyList<GetFilterIdNameDTO>> GetVsptCargo()
        {
            return await _mediator.Send(new GetSprCargoHandlerRequest { Data = Unit.Value });
        }
        [HttpGet("cargo/vspt_spr_cargo_group")]
        public async Task<IReadOnlyList<Spr_cargo_group>> GetVsptCargGroupo()
        {
            return await _mediator.Send(new GetSprCargoGroupHandlerRequest { Data = Unit.Value });
        }
    }
}
