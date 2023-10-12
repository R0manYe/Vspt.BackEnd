using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Filters
{
    public sealed record GetFilialsFilterHandlerRequest : BaseRequest<string, IReadOnlyList<GetFilterIdNameDTO>>
    {
    }
    internal sealed class GetFilialsFilterHandlerHandler : BaseRequestHandler<GetFilialsFilterHandlerRequest, string, IReadOnlyList<GetFilterIdNameDTO>>
    {       
        private readonly IFilterUserFilialsService _filterUserFilialsService;

        public GetFilialsFilterHandlerHandler(
            IFilterUserFilialsService filterUserFilialsService)
        {
            _filterUserFilialsService = filterUserFilialsService;

        }
        protected override async Task<IReadOnlyList<GetFilterIdNameDTO>> HandleData(string request, CancellationToken cancellationToken)
        {
            return await _filterUserFilialsService.GetIdNameFilials(request, cancellationToken);
                    
        }
    }
}
