using ConfigBuilder.UseCases.LoadConfig;

using Mediator.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ConfigBuilder.UseCases;

/// <summary>
/// Techniche Schulden
/// EIn Mediator soll mittels DI alle "Routen" UseCase-Handlers kennen
/// </summary>
public class MediatorPoorImpl : IMediator
{
	private readonly ConfigSessionsRepository _repository;

	public MediatorPoorImpl(ConfigSessionsRepository repository)
	{
		_repository = repository;
	}


	public async ValueTask<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
	{
		return await ((dynamic)this).When((dynamic)request);
	}

	private async ValueTask<ConfigLoadedDto> When(LoadConfigDto inDto)
	{
		return await new LoadConfigHandler(_repository).HandleAsync(inDto);
	}

}