using ConfigBuilder.Infrastructure;

namespace ConfigBuilder.UseCases.LoadConfig;

public class LoadConfigHandler
{
    private readonly IConfigLoader _configLoader;

    public LoadConfigHandler(GenericConfigLoader configLoader)
    {
        _configLoader = configLoader;
    }
    
    public async ValueTask<ConfigLoadedDto> HandleAsync(LoadConfigDto inputDto)
    {
        throw new NotImplementedException();
    }
}