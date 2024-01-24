using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Vspt.Box.MediatR
{
    public abstract class BaseRequestHandler<TRequest, TRequestData, TResponse> : IRequestHandler<TRequest, TResponse>
     where TRequest : BaseRequest<TRequestData, TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return HandleData(request.Data, cancellationToken);
        }
        protected abstract Task<TResponse> HandleData(TRequestData requestData, CancellationToken cancellationToken);
    }
}
