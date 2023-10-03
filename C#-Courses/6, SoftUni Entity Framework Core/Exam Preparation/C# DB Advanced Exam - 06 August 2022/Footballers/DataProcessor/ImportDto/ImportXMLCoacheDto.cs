namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Coach")]
public class ImportXMLCoacheDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    [XmlElement("Name")]
    public string Name { get; set; }

    [Required]
    [XmlElement("Nationality")]
    public string Nationality { get; set; }

    [XmlArray("Footballers")]
    public ImportXMLFootballerDto[] Footballers { get; set; }
}
