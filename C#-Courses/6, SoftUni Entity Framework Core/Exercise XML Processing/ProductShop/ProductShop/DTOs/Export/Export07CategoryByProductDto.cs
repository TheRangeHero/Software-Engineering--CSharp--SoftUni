using System.Xml;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Category")]
public class Export07CategoryByProductDto
{
    [XmlElement("name")]
    public string CategoryName { get; set; } = null!;

    [XmlElement("count")]
    public int ProductCount { get; set; }

    [XmlElement("averagePrice")]
    public decimal AveragePrice { get; set; }

    [XmlElement("totalRevenue")]
    public decimal TotalRevenue { get; set; }
}
