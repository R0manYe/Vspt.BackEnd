using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Windows.Markup;
using Vspt.BackEnd.Application.features.Filters;
using Vspt.BackEnd.Application.features.GetUser;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Application.features.IdentityRolees;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
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
        public Task<IReadOnlyList<GetFilterResponseDTO>> ReadDistricts(string userId)
        {
            return _mediator.Send(new GetDistrictFilterHandlerRequest { Data = userId });
        }
        [HttpGet("filterUserFilialsIdName")]
        public Task<IReadOnlyList<GetFilterResponseDTO>> ReadFilials(string userId)
        {
            return _mediator.Send(new GetFilialsFilterHandlerRequest { Data = userId });
        }
        [HttpGet("filterUserStationId")]
        public Task<IReadOnlyList<GetFilterIdRequestDTO>> GetUserStation(string userId)
        {
            return _mediator.Send(new GetUserFilialStationFilterHandlerRequest { Data = userId });
        }
    }
}
