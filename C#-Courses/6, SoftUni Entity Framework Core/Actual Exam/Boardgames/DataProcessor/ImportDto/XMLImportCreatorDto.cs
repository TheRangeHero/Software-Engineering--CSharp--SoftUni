using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Creator")]
public class XMLImportCreatorDto
{
    [XmlElement("FirstName")]
    [Required]
    [MinLength(2)]
    [MaxLength(7)]
    public string FirstName { get; set; }

    [XmlElement("LastName")]
    [Required]
    [MinLength(2)]
    [MaxLength(7)]
    public string LastName { get; set; }

    [XmlArray("Boardgames")]
    public XMLImportBoardGameDto[] Boardgames { get; set; }
}
