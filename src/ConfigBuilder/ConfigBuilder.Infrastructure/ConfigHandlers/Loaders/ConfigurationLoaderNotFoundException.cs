namespace ConfigBuilder.Infrastructure;

public class ConfigurationLoaderNotFoundException : Exception
{
	public ConfigurationLoaderNotFoundException(string uriScheme) : base($"Configuration loader not found for scheme {uriScheme}")
	{
		
	}
}