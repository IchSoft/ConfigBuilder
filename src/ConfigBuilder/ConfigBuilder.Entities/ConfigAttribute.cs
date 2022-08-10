namespace ConfigBuilder.Entities;

public class ConfigAttribute
{
	public string LocalName { get; }
	public object Value { get; }

	public ConfigAttribute(string localName, object value)
	{
		LocalName = localName;
		Value = value;
	}
}