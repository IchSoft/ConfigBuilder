using ConfigBuilder.Entities;

namespace ConfigBuilder.Infrastructure;

public interface IConfigLoader
{
	string ConfigType { get; }
    ValueTask<ConfigNode> LoadAsync(Uri configUri);
    
}