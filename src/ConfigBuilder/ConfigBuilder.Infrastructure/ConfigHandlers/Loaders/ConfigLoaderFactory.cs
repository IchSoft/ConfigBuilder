namespace ConfigBuilder.Infrastructure;

public class ConfigLoaderFactory
{
	private readonly Dictionary<string, IConfigLoader> _uriScheme2ConfigLoader;

	public ConfigLoaderFactory( IEnumerable<IConfigLoader> configLoaders)
	{
		if (configLoaders == null)
		{
			throw new ArgumentNullException(nameof(configLoaders));
		}
		//Lazy spasses halber?
		_uriScheme2ConfigLoader = new Dictionary<string, IConfigLoader>();

		foreach (IConfigLoader configLoader in configLoaders)
		{
			_uriScheme2ConfigLoader[configLoader.ConfigType] = configLoader;
		}
	}

	public IConfigLoader Create(string uriScheme)
	{
		if (!_uriScheme2ConfigLoader.TryGetValue(uriScheme, out IConfigLoader configLoader))
		{
			throw new ConfigurationLoaderNotFoundException(uriScheme);
		}

		return configLoader;
	}
}