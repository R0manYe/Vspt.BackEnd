using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using Tiss.Common.Api.Contracts.Pagination;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetReadClaimRequest : BaseRequest<Paging, IReadOnlyList<IdentityClaims>>
    {
    }
    internal sealed class GetReadClaimHandler : BaseRequestHandler<GetReadClaimRequest, Paging, IReadOnlyList<IdentityClaims>>
    {
        private readonly IClaimsRepository _claimsRepository;
        private readonly IMapper _mapper;


        public GetReadClaimHandler(IMapper mapper, IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
            _mapper = mapper;

        }

        protected override async Task<IReadOnlyList<IdentityClaims>> HandleData(Paging request, CancellationToken cancellationToken)
        {           
           return await _claimsRepository.GetReadClaims(request.Page, request.Size, cancellationToken);           

        }
    }
}
