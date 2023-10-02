using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Filters
{
    public sealed record GetFilialsFilterHandlerRequest : BaseRequest<string, IReadOnlyList<GetFilterResponseDTO>>
    {
    }
    internal sealed class GetFilialsFilterHandlerHandler : BaseRequestHandler<GetFilialsFilterHandlerRequest, string, IReadOnlyList<GetFilterResponseDTO>>
    {       
        private readonly IFilterUserFilialsService _filterUserFilialsService;

        public GetFilialsFilterHandlerHandler(
            IFilterUserFilialsService filterUserFilialsService)
        {
            _filterUserFilialsService = filterUserFilialsService;

        }
        protected override async Task<IReadOnlyList<GetFilterResponseDTO>> HandleData(string request, CancellationToken cancellationToken)
        {
            return await _filterUserFilialsService.GetFilials(request, cancellationToken);
                    
        }
    }
}
