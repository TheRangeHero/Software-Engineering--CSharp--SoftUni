using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("SoldProducts")]
public class ExportDTO08ProdictsForUser
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public List<ExportDTO08ProductSoldForUser> ProductsSold { get; set; } = null!;
}
