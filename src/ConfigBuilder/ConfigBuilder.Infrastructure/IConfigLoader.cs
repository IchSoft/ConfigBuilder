using ConfigBuilder.Entities;

namespace ConfigBuilder.Infrastructure;

public interface IConfigLoader
{
    ValueTask<ConfigNode> LoadAsync();
}