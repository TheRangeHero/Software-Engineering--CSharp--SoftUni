using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Product")]
public class ExportDTO08ProductSoldForUser
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }
}
