using Microsoft.Extensions.Logging;

namespace ConfigBuilder.Infrastructure;

public class FileConfigLoader : IConfigLoader
{
	private readonly ILogger<FileConfigLoader> _logger;
	public FileConfigLoader(ILogger<FileConfigLoader> logger)
	{
		_logger = logger;
	}

	public string ConfigType { get; } = Uri.UriSchemeFile;

	public ValueTask<Stream> LoadAsync(Uri configUri)
	{
		return ValueTask.FromResult((Stream)File.OpenRead(configUri.AbsoluteUri));
	}
}