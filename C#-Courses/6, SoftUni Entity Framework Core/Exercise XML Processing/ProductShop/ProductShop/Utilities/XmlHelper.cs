using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Utilities;
public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer deserializer = new XmlSerializer(typeof(T), xmlRoot);

        using StringReader stringReader = new StringReader(inputXml);
        T currentDto = (T)deserializer.Deserialize(stringReader);

        return currentDto;
    }
    public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer deserializer = new XmlSerializer(typeof(T[]), rootName);

        using StringReader stringReader = new StringReader(inputXml);
        T[] currentDto = (T[])deserializer.Deserialize(stringReader);

        return currentDto;
    }



    public string Serialize<T>(T obj, string rootName)
    {
        StringBuilder stringBuilder = new StringBuilder();

        XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRootAttribute);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using StringWriter stringWriter = new StringWriter(stringBuilder);
        xmlSerializer.Serialize(stringWriter, obj, namespaces);

        return stringBuilder.ToString().TrimEnd();
    }
    public string Serialize<T>(T[] obj, string rootName)
    {
        StringBuilder stringBuilder = new StringBuilder();

        XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRootAttribute);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using StringWriter stringWriter = new StringWriter(stringBuilder);
        xmlSerializer.Serialize(stringWriter, obj, namespaces);

        return stringBuilder.ToString().TrimEnd();
    }
}
