namespace Mediator.Abstractions;

public interface IMediatorSender
{
	ValueTask<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default);
}