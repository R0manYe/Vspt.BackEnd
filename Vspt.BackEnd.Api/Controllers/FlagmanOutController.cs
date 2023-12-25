using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.Services.SprOrg;
using Vspt.BackEnd.Application.Services.SubjectPersone;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("v1/vspt-flagman/")]
    [ApiController]
    [ApiVersionNeutral]    

    public class FlagmanOutController : ControllerBase
    {
        private readonly ISubjectPersoneService _subjectPersoneService;
        private readonly ISprOrgService _sprOrgService;
        private readonly IDislokaciaService _dislokaciaService;
        private readonly ISprCargoService _sprCargoService;

        public FlagmanOutController(
            ISubjectPersoneService subjectPersoneService, 
            ISprOrgService sprOrgService, 
            IDislokaciaService dislokaciaService,
            ISprCargoService sprCargoService
            )
        {
            _subjectPersoneService = subjectPersoneService;
            _sprOrgService = sprOrgService;
            _dislokaciaService = dislokaciaService;
            _sprCargoService = sprCargoService;
        }

        [HttpPost("list")]
        public Task<IReadOnlyList<Vspt_subject_personeDTO>> GetAllUsersSubjectPersone()
        {
            return _subjectPersoneService.GetAllSubjectPersone();           
        }
        [HttpPost("sprOrg")]
        public Task<IReadOnlyList<Spr_org>> GetSprOrg(IReadOnlyList<GetFilterIdRequestDTO> stations, CancellationToken cancellationToken)
        {
            return _sprOrgService.GetSprOrgResult(stations, cancellationToken); 
        }
        [HttpPost("sprDislokacia")]
        public Task<IReadOnlyList<GetAllDislokacia>> GetDislokacia(CancellationToken cancellationToken)
        {
            return _dislokaciaService.GetDislokacia(cancellationToken);
        }
        [HttpPost("sprDislokaciaFiltr")]
        public Task<IReadOnlyList<GetAllDislokacia>> GetDislokaciaStationFiltr(uint userId,CancellationToken cancellationToken)
        {
            return _dislokaciaService.GetDislokaciaFilterStations(userId,cancellationToken);
        }
        [HttpPost("sprCargo")]
        public Task<IReadOnlyList<GetFilterIdNameDTO>> GetCargo(CancellationToken cancellationToken)
        {
            return _sprCargoService.GetSprCargo(cancellationToken);
        }

    }
}
