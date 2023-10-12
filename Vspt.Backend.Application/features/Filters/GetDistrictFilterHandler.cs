using MassTransit.Initializers;
using Vspt.BackEnd.Application.Services.Filters.District;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Filters;

public sealed record GetDistrictFilterHandlerRequest : BaseRequest<string, IReadOnlyList<GetFilterIdNameDTO>>
{
}
internal sealed class GetDistrictFilterHandlerHandler : BaseRequestHandler<GetDistrictFilterHandlerRequest, string, IReadOnlyList<GetFilterIdNameDTO>>
{
    private readonly IFilterUserDistrictsService _filterUserDistrictsService;

    public GetDistrictFilterHandlerHandler(IFilterUserDistrictsService sprDistrictsRepository)
    {
        _filterUserDistrictsService = sprDistrictsRepository;
    }
    protected override async Task<IReadOnlyList<GetFilterIdNameDTO>> HandleData(string request, CancellationToken cancellationToken)
    {
        return await _filterUserDistrictsService.GetDistricts(request, cancellationToken);
    }
}
