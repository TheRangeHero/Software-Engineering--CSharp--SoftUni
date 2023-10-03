namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("Product")]
public class ExportSoldProductforUserDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }
}
