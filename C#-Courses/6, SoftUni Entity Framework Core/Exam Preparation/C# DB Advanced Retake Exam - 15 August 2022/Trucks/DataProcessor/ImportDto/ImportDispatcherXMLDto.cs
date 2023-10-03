namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Despatcher")]
public class ImportDispatcherXMLDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(2)]
    [MaxLength(40)]
    public string Name { get; set; }

    [XmlElement("Position")]
    public string Position { get; set; }

    [XmlArray("Trucks")]
    public ImportTruckXMLDto[] Trucks { get; set; }
}
