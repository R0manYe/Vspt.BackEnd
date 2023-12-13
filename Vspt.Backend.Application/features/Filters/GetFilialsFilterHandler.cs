using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Filters
{
    public sealed record GetFilialsFilterHandlerRequest : BaseRequest<uint, IReadOnlyList<GetFilterIdLongNameDTO>>
    {
    }
    internal sealed class GetFilialsFilterHandlerHandler : BaseRequestHandler<GetFilialsFilterHandlerRequest, uint, IReadOnlyList<GetFilterIdLongNameDTO>>
    {       
        private readonly IFilterUserFilialsService _filterUserFilialsService;

        public GetFilialsFilterHandlerHandler(IFilterUserFilialsService filterUserFilialsService)
        {
            _filterUserFilialsService = filterUserFilialsService;
        }
        protected override async Task<IReadOnlyList<GetFilterIdLongNameDTO>> HandleData(uint request, CancellationToken cancellationToken)
        {
            return await _filterUserFilialsService.GetIdNameFilials(request, cancellationToken);                    
        }
    }
}
