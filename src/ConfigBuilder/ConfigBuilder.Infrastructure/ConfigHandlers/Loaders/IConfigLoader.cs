namespace ConfigBuilder.Infrastructure;

public interface IConfigLoader
{
	string ConfigType { get; }
	ValueTask<Stream> LoadAsync(Uri configUri);
    
}