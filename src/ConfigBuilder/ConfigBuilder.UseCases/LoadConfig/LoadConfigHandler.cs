using ConfigBuilder.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

namespace ConfigBuilder.UseCases.LoadConfig;

public class LoadConfigHandler
{
    private readonly ConfigSessionsRepository _repository;

    public LoadConfigHandler(ConfigSessionsRepository repository)
    {
	    _repository = repository;
    }
    
    public async ValueTask<ConfigLoadedDto> HandleAsync(LoadConfigDto inputDto)
    {
        throw new NotImplementedException();
    }
}