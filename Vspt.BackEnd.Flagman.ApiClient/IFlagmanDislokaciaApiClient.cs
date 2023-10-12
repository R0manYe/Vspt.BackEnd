using Refit;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Flagman.ApiClients;

public partial interface IFlagmanDislokaciaApiClient
	{
    /// <summary>
    /// Выборка организаций
    /// </summary>	

    [Get("/api/Flagman/dislokacia")]
    Task<IReadOnlyList<GetAllDislokacia>> GetDislokacia(CancellationToken cancellationToken = default);

    [Post("/api/Flagman/dislokaciaFiltrStation")]
    Task<IReadOnlyList<GetAllDislokacia>> GetDislokaciaFiltrStation(IReadOnlyList<GetFilterIdRequestDTO> stations, CancellationToken cancellationToken = default);

}
