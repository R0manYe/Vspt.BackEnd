using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Flagman.Application.features
{
    public sealed record GetVsptSubjectPersoneHandlerRequest : BaseRequest<Unit,List<Vspt_subject_persone>>
    {
    }
    internal sealed class GetVsptSubjectPersoneHandler : BaseRequestHandler<GetVsptSubjectPersoneHandlerRequest,Unit, List<Vspt_subject_persone>>
    {
        private readonly IVsptSubjectPersoneRepository _vsptSubjectPersoneRepository;

        public GetVsptSubjectPersoneHandler(IVsptSubjectPersoneRepository vsptSubjectPersoneRepository)
        {
            _vsptSubjectPersoneRepository = vsptSubjectPersoneRepository;
        }

        protected override async Task<List<Vspt_subject_persone>> HandleData (Unit unit, CancellationToken cancellationToken)
        {
            return await _vsptSubjectPersoneRepository.GetVsptSubjectPersone(cancellationToken);
        }
    }
}
