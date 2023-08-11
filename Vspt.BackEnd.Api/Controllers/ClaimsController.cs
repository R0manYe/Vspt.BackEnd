﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Windows.Markup;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("read")]
        public Task<IReadOnlyList<IdentityClaims>> ReadClaims()
        {
            return _mediator.Send(new GetReadClaimRequest { Data = Unit.Value });
        }

        [HttpPost("add")]
        public Task AddClaims( GetClaimRequest claimName)
        {
            return _mediator.Send(new GetAddClaimRequest { Data = claimName });
        }

        [HttpPut("update/{id}")]
        public Task UpdateClaims( Guid id,IdentityClaims request) 
        {
            return _mediator.Send(new GetUpdateClaimRequest { Data = new() { Id = id, 
                ClaimName=request.ClaimName, ClaimType=request.ClaimType, ClaimValue=request.ClaimValue}  } );
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteClaims(Guid id) 
        {
            return _mediator.Send(new GetDeleteClaimRequest { Data = new() { Id = id } });
        }
    }
}
