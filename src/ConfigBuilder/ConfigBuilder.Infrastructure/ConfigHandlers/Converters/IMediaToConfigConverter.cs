using ConfigBuilder.Entities;

namespace ConfigBuilder.Infrastructure;

public interface IMediaToConfigConverter
{
	ValueTask<ConfigNode> ConvertAsync(Stream mediaStream);
}