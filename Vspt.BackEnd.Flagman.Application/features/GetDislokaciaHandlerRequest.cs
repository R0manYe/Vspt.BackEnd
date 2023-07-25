using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.PublishModels.Dislokacia;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Flagman.Application.features
{
    public sealed record GetDislokaciaHandlerRequest : BaseRequest<Unit, List<GetAllDislokacia>>
    {
    }
    internal sealed class GetDislokaciaHandler : BaseRequestHandler<GetDislokaciaHandlerRequest, Unit, List<GetAllDislokacia>>
    {
        private readonly IDislokaciaRepository _dislokaciaRepository;         

        public GetDislokaciaHandler(IDislokaciaRepository usersRepository)
        {
            _dislokaciaRepository = usersRepository;            
        }

        protected override async Task<List<GetAllDislokacia>> HandleData(Unit unit, CancellationToken cancellationToken)
        {
          return await _dislokaciaRepository.GetDislokacia(cancellationToken);  
        }
    }
}
