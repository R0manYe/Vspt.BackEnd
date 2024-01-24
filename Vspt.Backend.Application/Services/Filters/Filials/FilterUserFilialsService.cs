using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contract.Postgrees.ViewModels;



namespace Vspt.BackEnd.Application.Services.Filters.Filials
{
    public class FilterUserFilialsService : IFilterUserFilialsService
    {
        private readonly IIdentityClaimsRepository _identityClaimsRepository;
        private readonly ISprFilialsRepository _sprFilialsRepository;
        public FilterUserFilialsService(IIdentityClaimsRepository identityClaimsRepository, ISprFilialsRepository sprFilialsRepository)
        {
            _identityClaimsRepository = identityClaimsRepository;
            _sprFilialsRepository = sprFilialsRepository;
        }
        
        public async Task<IReadOnlyList<GetFilterIdLongNameDTO>> GetIdNameFilials(uint username, CancellationToken cancellationToken)
        {
            var existAviliableFilials = await _identityClaimsRepository.GetFilterClaim(username,(byte)TypeClaim.Filials, cancellationToken);
            var checkAllFilial = existAviliableFilials.Where(x => x.Id == (byte)TypeClaim.Filials).Count();
            var avaliableFilials = await _sprFilialsRepository.GetAllFilials(cancellationToken);
            if (checkAllFilial == 0)
            {
                return existAviliableFilials.Select(x => new GetFilterIdLongNameDTO
                {
                    Id = avaliableFilials.Where(y =>y.Id == x.Id).Select(z => z.Id).First(),
                    Name = avaliableFilials.Where(y => y.Id == x.Id).Select(z => z.Name).First()
                }).ToList();
            }
            else
            {
                return avaliableFilials.Where(s => s.Id > 1).Select(x => new GetFilterIdLongNameDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
        }
        public async Task<IReadOnlyList<GetFilterIdResponseDTO>> GetIdFilials(uint username, CancellationToken cancellationToken)
        {
            var existAviliableFilials = await _identityClaimsRepository.GetFilterClaim(username,(byte)TypeClaim.Filials, cancellationToken);
            var checkAllFilial = existAviliableFilials.Where(x => x.Id == (byte)TypeClaim.Filials).Count();
            var avaliableFilials = await _sprFilialsRepository.GetAllFilials(cancellationToken);
            if (checkAllFilial == 0)
            {
                return existAviliableFilials.Select(x =>new  GetFilterIdResponseDTO
                { Id=x.Id}).ToList();            
               
            }
            else
            {
                return avaliableFilials.Where(s => s.Id > 1).Select(x => new GetFilterIdResponseDTO
                { Id = x.Id}).ToList();
            }
            
        }

    }
}