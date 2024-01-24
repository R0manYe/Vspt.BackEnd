using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Flagman.Application.features
{
    public sealed record GetVsptSubjectPersoneIdNameHandlerRequest : BaseRequest<Unit,IReadOnlyList<Vspt_subject_personeFIODTO>>
    {
    }
    internal sealed class GetVsptSubjectPersoneIdNameHandler : BaseRequestHandler<GetVsptSubjectPersoneIdNameHandlerRequest, Unit, IReadOnlyList<Vspt_subject_personeFIODTO>>
    {
        private readonly IVsptSubjectPersoneRepository _vsptSubjectPersoneRepository;

        public GetVsptSubjectPersoneIdNameHandler(IVsptSubjectPersoneRepository vsptSubjectPersoneRepository)
        {
            _vsptSubjectPersoneRepository = vsptSubjectPersoneRepository;
        }

        protected override async Task<IReadOnlyList<Vspt_subject_personeFIODTO>> HandleData (Unit unit, CancellationToken cancellationToken)
        {
            return await _vsptSubjectPersoneRepository.GetVsptSubjectPersoneFIO(cancellationToken);
           
        }
    }
}
