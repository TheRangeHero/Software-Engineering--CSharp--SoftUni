namespace CarDealer.Utilities;

using CarDealer.DTOs.Export;
using CarDealer.Models;
using System.Text;
using System.Xml.Serialization;

public class XmlHelper
{
    public T Deserialize<T> (string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T),xmlRoot);

        StringReader stringReader = new StringReader(inputXml);
        T currentDto = (T)xmlSerializer.Deserialize(stringReader);

        return currentDto;
        
    }

    public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

        StringReader stringReader = new StringReader(inputXml);
        T[] currentDto = (T[])xmlSerializer.Deserialize(stringReader);

        return currentDto;
    }


    //Serialize<ExportDto[]>(ExportDto[], rootName)
    //Serialize<ExportDto>(ExportDto, rootname)
    public string Serialize<T> (T obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter(sb);
        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }

    //Serialize<ExportDto>(ExportDto[], rootname)

    public string Serialize<T>(T[] obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter(sb);
        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }
}
