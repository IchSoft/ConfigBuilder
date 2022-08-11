using ConfigBuilder.Entities;

namespace ConfigBuilder.Infrastructure;

public interface IConfigToMediaConverter
{
	ValueTask<Stream> ConvertAsync(ConfigNode configNode);
}