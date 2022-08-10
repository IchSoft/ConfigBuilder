namespace ConfigEditor;

public class NodeAttributeViewModel
{
    public string LocalName { get; }
    public object Value { get; }

    public NodeAttributeViewModel(string localName, object value)
    {
	    LocalName = localName;
	    Value = value;
    }
}