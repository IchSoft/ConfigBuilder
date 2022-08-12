namespace Microsoft.Extensions.DependencyInjection;

public class ConfigAllreadyLoadedException : Exception
{
	public ConfigAllreadyLoadedException(Uri configUri) : base()
	{
		
	}
}