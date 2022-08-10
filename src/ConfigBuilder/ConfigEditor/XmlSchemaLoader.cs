using System.IO;
using System.Xml.Schema;

namespace ConfigEditor;

public class XmlSchemaLoader
{
    public void Load(string path)
    {
        XmlSchema xsd;
        using (FileStream stream = File.OpenRead(path))
        {
            xsd = XmlSchema.Read(stream, null);
        }
        
      

    }
}