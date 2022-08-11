using ConfigBuilder.Entities;

using Microsoft.Extensions.Logging;

namespace ConfigBuilder.Infrastructure;

public class FileConfigLoader : IConfigLoader
{
	private readonly ILogger<FileConfigLoader> _logger;
	private readonly IMediaToConfigConverter _converter;

	public FileConfigLoader(IMediaToConfigConverter converter, ILogger<FileConfigLoader> logger)
	{
		_converter = converter;
		_logger = logger;
	}

	public string ConfigType { get; } = Uri.UriSchemeFile;

	public async ValueTask<ConfigNode> LoadAsync(Uri configUri)
	{
		//Eigentlich nicht unbedingt nötig wie auch alle anderen Konstrukts
		if (configUri.Scheme != Uri.UriSchemeFile)
		{
			UriFormatException exception = new UriFormatException($"Scheme {configUri.Scheme} not allowed for file");
			//bei Logger lieber ohne $"..." arbeiten, da je nach loglevel keine Ausführung der Parameter erfolgt
			_logger.LogError(exception, exception.Message);
			throw exception;
		}

		using (FileStream configFileStream = File.OpenRead(configUri.AbsoluteUri))
		{
			return await _converter.ConvertAsync(configFileStream);
		}

	}
}