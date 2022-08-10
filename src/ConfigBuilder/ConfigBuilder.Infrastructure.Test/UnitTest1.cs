using System.Xml.Schema;

namespace ConfigBuilder.Infrastructure.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var xsdPath = Path.Combine(Path.GetDirectoryName(typeof(UnitTest1).Assembly.Location), "Schema.xsd");
        XmlSchema xsd;
        using (FileStream stream = File.OpenRead(xsdPath))
        {
            xsd = XmlSchema.Read(stream, null);
        }

        foreach (XmlSchemaObject item in xsd.Items)
        {
            if (item is XmlSchemaElement el)
            {
                string elName = el.Name;
            }
            else
            {
                XmlSchemaObject parent = item.Parent;
            }

        }
    }
}