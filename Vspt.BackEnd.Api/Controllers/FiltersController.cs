using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.features.Filters;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FiltersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("filterUserDistrictsIdName")]
        public Task<IReadOnlyList<GetFilterIdLongNameDTO>> ReadDistricts(uint userId)
        {
            return _mediator.Send(new GetDistrictFilterHandlerRequest { Data = userId });
        }
        [HttpGet("filterUserFilialsIdName")]
        public Task<IReadOnlyList<GetFilterIdLongNameDTO>> ReadFilials(uint userId)
        {
            return _mediator.Send(new GetFilialsFilterHandlerRequest { Data = userId });
        }
        [HttpGet("filterUserStationId")]
        public Task<IReadOnlyList<GetFilterIdRequestDTO>> GetUserStation(uint userId)
        {
            return _mediator.Send(new GetUserFilialStationFilterHandlerRequest { Data = userId });
        }
    }
}
