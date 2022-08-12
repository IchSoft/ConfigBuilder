using ConfigBuilder.Entities;
using ConfigBuilder.Infrastructure;
using ConfigBuilder.Infrastructure.ConfigHandlers;
using ConfigBuilder.Utilities;

using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection;

public class ConfigSessionsRepository
{
	private ConfigNode _config;
	
	
	private readonly IConfigLoader _configLoader;
	private readonly IMediaToConfigConverter _inConverter;
	private readonly IConfigToMediaConverter _outConverter;
	private readonly ILogger<ConfigSessionsRepository> _logger;
	private readonly IConfigWriter _configWriter;

	public ConfigSessionsRepository(GenericConfigLoader configLoader,
									IConfigWriter configWriter,
									IMediaToConfigConverter inConverter,
									IConfigToMediaConverter outConverter,
									ILogger<ConfigSessionsRepository> logger)
	{
		_configLoader = configLoader;
		_configWriter = configWriter;
		_inConverter = inConverter;
		_outConverter = outConverter;
		_logger = logger;
	}
	
	public async ValueTask<ConditionalObject<ConfigNode>> TryLoadAsync(Uri configUri)
	{
		if (_config != null)
		{
			_logger.LogError(new ConfigAllreadyLoadedException(configUri), "ConfigAllreadyLoadedException");
			//bzw. eine Exception werfen
			return new ConditionalObject<ConfigNode>(false, null);
		}

		using (Stream inStream = await _configLoader.LoadAsync(configUri))
		{
			return new ConditionalObject<ConfigNode>(true, await _inConverter.ConvertAsync(inStream));
		}
	}

	public async ValueTask SaveAsync(Uri configUri)
	{
		if (_config == null)
		{
			// exeption werfen
			_logger.LogError(new NoConfigFoundException(), "NoConfigFoundException()");
			return;
		}

		await _configWriter.WriteAsync(configUri);
	}
}