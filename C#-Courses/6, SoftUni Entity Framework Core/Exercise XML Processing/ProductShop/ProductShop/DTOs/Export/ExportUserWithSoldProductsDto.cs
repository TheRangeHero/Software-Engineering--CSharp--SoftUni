namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("User")]
public class ExportUserWithSoldProductsDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; } = null!;

    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;

    [XmlElement("soldProducts")]
    public ExportSoldProductforUserDto[] SoldProducts { get; set; }
}
