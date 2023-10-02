using Vspt.BackEnd.Domain.Contract;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.Services.Filters.District
{
    public class FilterUserDistrictsService : IFilterUserDistrictsService
    {
        private readonly IIdentityClaimsRepository _identityClaimsRepository;
        private readonly ISprDistrictsRepository _sprDistrictsRepository;
        public FilterUserDistrictsService(IIdentityClaimsRepository identityClaimsRepository, ISprDistrictsRepository sprDistrictsRepository)
        {
            _identityClaimsRepository = identityClaimsRepository;
            _sprDistrictsRepository = sprDistrictsRepository;
        }

        public async Task<IReadOnlyList<GetFilterResponseDTO>> GetDistricts(string username, CancellationToken cancellationToken)
        {
            var existAviliableDistricts = await _identityClaimsRepository.GetDistrictsClaim(username, cancellationToken);
            var checkAllFilial = existAviliableDistricts.Where(x => x.Id == "1").Count();
            var avaliableDistricts = await _sprDistrictsRepository.GetAllDistricts(cancellationToken);
            if (checkAllFilial == 0)
            {
                return existAviliableDistricts.Select(x => new GetFilterResponseDTO
                {
                    Id = avaliableDistricts.Where(y => y.Id == x.Id).Select(z => z.Id).First(),
                    Name = avaliableDistricts.Where(y => y.Id == x.Id).Select(z => z.Name).First()
                }).ToList();
            }
            else
            {
                return avaliableDistricts.Where(s => s.Id.Length > 1).Select(x => new GetFilterResponseDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
        }
    }
}