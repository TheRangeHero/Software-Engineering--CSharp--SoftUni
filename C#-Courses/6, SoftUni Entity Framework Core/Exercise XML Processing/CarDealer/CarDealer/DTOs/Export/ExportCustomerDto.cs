namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("customer")]
public class ExportCustomerDto
{

    public ExportCustomerDto()
    {

    }

    public ExportCustomerDto(string fullName, string boughtCars, decimal spentMoney)
    {
        this.Name = fullName;
        this.BoughtCars = boughtCars;
        this.SpentMoney = spentMoney;
    }
    [XmlAttribute("full-name")]
    public string Name { get; set; } = null!;

    [XmlAttribute("bought-cars")]
    public string BoughtCars { get; set; }

    [XmlAttribute("spent-money")]
    public decimal SpentMoney { get; set; }
}
