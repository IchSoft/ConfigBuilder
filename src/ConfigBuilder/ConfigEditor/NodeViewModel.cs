using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConfigEditor;

public class NodeViewModel : AbstractViewModel
{
    public string Name { get; set; }

    public ObservableCollection<NodeViewModel> ChildNodes { get; set; }
    
    // public NodeViewModel Parent { get; set; }
    
    public ObservableCollection<NodeAttributeViewModel> Attributes { get; set; }

}