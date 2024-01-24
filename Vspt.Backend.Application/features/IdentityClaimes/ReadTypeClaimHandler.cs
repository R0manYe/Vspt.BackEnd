using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Repositories;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes;

public sealed record ReadTypeClaimRequest : BaseRequest<Unit,IReadOnlyList<TypeClaims>>
{
}
internal sealed class ReadTypeClaimHandler : BaseRequestHandler<ReadTypeClaimRequest,Unit,IReadOnlyList<TypeClaims>>
{
    private readonly ITypeClaimsRepository _typeClaimsRepository;
    


    public ReadTypeClaimHandler(ITypeClaimsRepository typeClaimsRepository)
    {
        _typeClaimsRepository = typeClaimsRepository;
        

    }

    protected override async Task<IReadOnlyList<TypeClaims>> HandleData(Unit unit, CancellationToken cancellationToken)
    {
        return await _typeClaimsRepository.GetReadTypeClaims(cancellationToken);

    }
}
