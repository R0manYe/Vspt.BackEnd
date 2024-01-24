using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.PublishModels.Dislokacia;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Application.features;

public sealed record GetDislokaciaFilterStationHandlerRequest : BaseRequest<IReadOnlyList<GetFilterIdRequestDTO>, List<GetAllDislokacia>>
{
}
internal sealed class GetDislokaciaFilterStationHandler : BaseRequestHandler<GetDislokaciaFilterStationHandlerRequest, IReadOnlyList<GetFilterIdRequestDTO>, List<GetAllDislokacia>>
{
    private readonly IDislokaciaRepository _dislokaciaRepository;         

    public GetDislokaciaFilterStationHandler(IDislokaciaRepository usersRepository)
    {
        _dislokaciaRepository = usersRepository;            
    }

    protected override async Task<List<GetAllDislokacia>> HandleData(IReadOnlyList<GetFilterIdRequestDTO> stations, CancellationToken cancellationToken)
    {
      return await _dislokaciaRepository.GetDislokaciaFilter(stations,cancellationToken);  
    }
}
