using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using static MassTransit.ValidationResultExtensions;

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

        public async Task<IReadOnlyList<GetFilterIdNameDTO>> GetIdNameFilials(string username, CancellationToken cancellationToken)
        {
            var existAviliableFilials = await _identityClaimsRepository.GetFilialsClaim(username, cancellationToken);
            var checkAllFilial = existAviliableFilials.Where(x => x.Id == "1").Count();
            var avaliableFilials = await _sprFilialsRepository.GetAllFilials(cancellationToken);
            if (checkAllFilial == 0)
            {
                return existAviliableFilials.Select(x => new GetFilterIdNameDTO
                {
                    Id = avaliableFilials.Where(y => y.Id == x.Id).Select(z => z.Id).First(),
                    Name = avaliableFilials.Where(y => y.Id == x.Id).Select(z => z.Name).First()
                }).ToList();
            }
            else
            {
                return avaliableFilials.Where(s => s.Id.Length > 1).Select(x => new GetFilterIdNameDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
        }
        public async Task<IReadOnlyList<GetFilterIdResponseDTO>> GetIdFilials(string username, CancellationToken cancellationToken)
        {
            var existAviliableFilials = await _identityClaimsRepository.GetFilialsClaim(username, cancellationToken);
            var checkAllFilial = existAviliableFilials.Where(x => x.Id == "1").Count();
            var avaliableFilials = await _sprFilialsRepository.GetAllFilials(cancellationToken);
            if (checkAllFilial == 0)
            {
                return existAviliableFilials.Select(x =>new  GetFilterIdResponseDTO
                { Id=x.Id}).ToList();            
               
            }
            else
            {
                return avaliableFilials.Where(s => s.Id.Length > 1).Select(x => new GetFilterIdResponseDTO
                { Id = x.Id}).ToList();
            }
            
        }

    }
}