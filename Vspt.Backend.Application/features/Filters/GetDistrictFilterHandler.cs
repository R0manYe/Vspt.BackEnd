using MassTransit.Initializers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Flagman.ApiClients;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.GetFlagman;
using Vspt.Common.Api.Contract.Postgrees.Filters;

namespace Vspt.BackEnd.Application.features.Filters
{
    public sealed record GetDistrictFilterHandlerRequest : BaseRequest<string, IReadOnlyList<GetFilterResponseDTO>>
    {
    }
    internal sealed class GetDistrictFilterHandlerHandler : BaseRequestHandler<GetDistrictFilterHandlerRequest, string, IReadOnlyList<GetFilterResponseDTO>>
    {
        private readonly IIdentityClaimsRepository _identityClaimsRepository;
        private readonly ISprDistrictsRepository _sprDistrictsRepository;

        public GetDistrictFilterHandlerHandler(
            IIdentityClaimsRepository identityClaimsRepository,
            ISprDistrictsRepository sprDistrictsRepository)
        {
            _identityClaimsRepository = identityClaimsRepository;
            _sprDistrictsRepository = sprDistrictsRepository;

        }
        protected override async Task<IReadOnlyList<GetFilterResponseDTO>> HandleData(string request, CancellationToken cancellationToken)
        {
            var existAviliableDistricts = await _identityClaimsRepository.GetDistrictsClaim(request, cancellationToken);
            var checkAllDistrict = existAviliableDistricts.Where(x => x.Id == "1").Count();
            var avaliableDistricts = await _sprDistrictsRepository.GetAllDistricts(cancellationToken);
            if (checkAllDistrict == 0)
            {

                return existAviliableDistricts.Select(x => new GetFilterResponseDTO
                {
                    Id = avaliableDistricts.Where(y => y.Id == x.Id).Select(z => z.District_id_txt).First(),
                    Name = avaliableDistricts.Where(y => y.Id == x.Id).Select(z => z.Name).First()
                }).ToList();
            }
            else
            {
                return avaliableDistricts.Where(s=>s.Id.Length>2).Select(x => new GetFilterResponseDTO
                { 
                    Id = x.District_id_txt, 
                    Name = x.Name 
                }).ToList();
            }

        }
    }
}
