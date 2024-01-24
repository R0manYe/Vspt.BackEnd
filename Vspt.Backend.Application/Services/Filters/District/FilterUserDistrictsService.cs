using Vspt.BackEnd.Domain.Contract;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contract.Postgrees.ViewModels;

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

        public async Task<IReadOnlyList<GetFilterIdLongNameDTO>> GetDistricts(uint username, CancellationToken cancellationToken)
        {

            
            var existAviliableDistricts = await _identityClaimsRepository.GetFilterClaim(username,(byte)TypeClaim.Districts, cancellationToken);
            var checkAllDistricts = existAviliableDistricts.Where(x => x.Id == (uint)TypeClaim.Districts).Count();
            var avaliableDistricts = await _sprDistrictsRepository.GetAllDistricts(cancellationToken);
            if (checkAllDistricts == 1)
            {
                return existAviliableDistricts.Select(x => new GetFilterIdLongNameDTO
                {
                    Id = avaliableDistricts.Where(y => y.Id == x.Id).Select(z => z.Id).First(),
                    Name = avaliableDistricts.Where(y => y.Id == x.Id).Select(z => z.Name).First()
                }).ToList();
            }
            else
            {
                return avaliableDistricts.Where(s => s.Id > 1).Select(x => new GetFilterIdLongNameDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
        }
    }
}