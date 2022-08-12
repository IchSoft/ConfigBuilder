using ConfigBuilder.Entities;

namespace ConfigBuilder.Infrastructure;

public class GenericConfigLoader : IConfigLoader
{
	private readonly ConfigLoaderFactory _configLoaderFactory;
	public string ConfigType { get; }

	public GenericConfigLoader(ConfigLoaderFactory configLoaderFactory)
	{
		_configLoaderFactory = configLoaderFactory;
	}
	
	public async ValueTask<Stream> LoadAsync(Uri configUri)
	{
		return await _configLoaderFactory.Create(configUri.Scheme).LoadAsync(configUri);
	}
}