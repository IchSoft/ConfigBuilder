using ConfigBuilder.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;


/// <summary>
/// Noch falscher Ort (Projekt)
/// </summary>
public static class ConfigLoaderExtensions
{
	public static IServiceCollection AddConfigLoader(this IServiceCollection services)
	{
		services
			.AddSingleton<IConfigLoader, FileConfigLoader>()
			.AddSingleton<GenericConfigLoader>();
		return services;
	}
}