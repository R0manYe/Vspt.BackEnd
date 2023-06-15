using MediatR;

namespace Vspt.Box.MediatR
{
    public record BaseRequest<TRequestData, TResponse> : IRequestWithData<TRequestData>, IRequest<TResponse>
    {
        public required TRequestData Data { get; init; }
    }
}
