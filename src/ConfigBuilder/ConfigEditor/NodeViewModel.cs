using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConfigEditor;

public class NodeViewModel : AbstractViewModel
{
    public string LocalName { get; }
    public ObservableCollection<NodeViewModel> ChildNodes { get; set; } = new ObservableCollection<NodeViewModel>();
    
    // public NodeViewModel Parent { get; set; }
    
    public ObservableCollection<NodeAttributeViewModel> Attributes { get; set; }
    
    public string Text { get; set; }

    public NodeViewModel(string localName)
    {
	    LocalName = localName;
    }

}