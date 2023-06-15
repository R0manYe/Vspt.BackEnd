namespace Vspt.Box.MediatR;

public interface IRequestWithData<TRequestData>
{
    public TRequestData Data { get; }
}
