namespace ConfigBuilder.Entities;

/// <summary>
/// Kein Immutable
/// </summary>
public class ConfigNode
{
	/// <summary>
	/// Evtl. so, ähnlich wie beim xslt, um Nodes bearbeiten zu können. Die ID ist flüchtig. Bzw. anhand des Pfades (?)
	/// </summary>
	// public string SessionNodeId { get; }
	public string LocalName { get; }
	
	// public ConfigNode Parent { get; }

	/// <summary>
	/// Noch schlecht mit new List...
	/// </summary>
	public List<ConfigNode> ChildNodes { get; private set; } = new List<ConfigNode>();

	public List<ConfigAttribute> Attributes { get; private set; } = new List<ConfigAttribute>();
    
	public string Text { get; private set; }

	// public ConfigNode(string sessionNodeId, string localName, ConfigNode parent)
	// {
	// 	SessionNodeId = sessionNodeId;
	// 	LocalName = localName;
	// 	Parent = parent;
	// }
	
	public ConfigNode(string localName)
	{
		LocalName = localName;
	}

	public ConfigNode SetText(string text)
	{
		Text = text;
		return this;
	}

	public ConfigNode AddAttribute(string localName, string value)
	{
		Attributes.Add(new ConfigAttribute(localName, value));

		return this;
	}
	
	public ConfigNode AddChildNode(ConfigNode childNode)
	{
		ChildNodes.Add(childNode);

		return this;
	}
	
	public ConfigNode AddChildNode(Action<ConfigNode> factory, string localName)
	{
		ConfigNode childNode = new ConfigNode(localName);
		factory.Invoke(childNode);
		ChildNodes.Add(childNode);

		return this;
	}
}