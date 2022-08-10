using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.XPath;

namespace ConfigEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string dir = System.IO.Path.GetDirectoryName(typeof(MainWindow).Assembly.Location);
            using (FileStream configFileStream = File.OpenRead(System.IO.Path.Combine(dir, "Ressources", "Config_full.xml")))
            using (XmlReader xmlReader = XmlReader.Create(configFileStream))
            {
	            RootNode = Extract(xmlReader);
            }

            base.DataContext = RootNode;
        }
        
        public static RoutedUICommand OpenConfigFileCommand { get; private set; }
        
        public NodeViewModel RootNode { get; set; }
        
        public NodeViewModel Extract(XmlReader reader)
        {
	        Stack<NodeViewModel> stack = new Stack<NodeViewModel>();

	        NodeViewModel rootNode = null;

	        while (reader.Read())
	        {
		        switch (reader.NodeType)
		        {
			        case XmlNodeType.Document:
			        case XmlNodeType.DocumentFragment:
			        case XmlNodeType.DocumentType:
			        case XmlNodeType.XmlDeclaration:
			        case XmlNodeType.Notation:
				        break;
			        case XmlNodeType.Comment:
				        break;
			        case XmlNodeType.ProcessingInstruction:
				        break;
			        case XmlNodeType.Whitespace:
				        break;
			        case XmlNodeType.SignificantWhitespace:
			        case XmlNodeType.CDATA:
			        case XmlNodeType.Text:
				        stack.Peek().Text = reader.Value;
				        break;
			        case XmlNodeType.Element:
				        NodeViewModel model = new NodeViewModel(reader.LocalName);
				        if (stack.Count == 0)
				        {
					        rootNode = model;
				        }
				        else
				        {
					        stack.Peek().ChildNodes.Add(model);
				        }

				        if (reader.HasAttributes)
				        {
					        model.Attributes = new ObservableCollection<NodeAttributeViewModel>();

					        while (reader.MoveToNextAttribute())
					        {
						        model.Attributes.Add(new NodeAttributeViewModel(reader.LocalName, reader.Value));
					        }

					        reader.MoveToElement();
				        }

				        if (!reader.IsEmptyElement)
				        {
					        stack.Push(model);
				        }

				        break;
			        case XmlNodeType.EndElement:
				        stack.Pop();
				        break;
		        }
	        }

	        return rootNode;
        }
    }
}