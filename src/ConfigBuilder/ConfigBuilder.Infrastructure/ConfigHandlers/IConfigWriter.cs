namespace ConfigBuilder.Infrastructure.ConfigHandlers;

/// <summary>
/// TODO: die Namen Writer und Loader sind unsymmetrisch, Loader in Reader umbenennen
/// </summary>
public interface IConfigWriter
{
	ValueTask WriteAsync(Uri configUri);
}