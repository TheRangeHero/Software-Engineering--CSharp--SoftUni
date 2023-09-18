namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Truck")]
public class ImportTruckXMLDto
{
    [Required]
    [XmlElement("RegistrationNumber")]
    [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
    public string RegistrationNumber { get; set; }

    [XmlElement("VinNumber")]
    [Required]
    [StringLength(17)]
    public string VinNumber { get; set; } = null!;

    [XmlElement("TankCapacity")]
    [Range(950,1420)]
    public int TankCapacity { get; set; }

    [XmlElement("CargoCapacity")]
    [Range(5000,29000)]
    public int CargoCapacity { get; set; }

    [XmlElement("CategoryType")]
    [Required]
    [Range(0,3)]
    public int CategoryType { get; set; }

    [XmlElement("MakeType")]
    [Required]
    [Range(0,4)]
    public int MakeType { get; set; }
}
