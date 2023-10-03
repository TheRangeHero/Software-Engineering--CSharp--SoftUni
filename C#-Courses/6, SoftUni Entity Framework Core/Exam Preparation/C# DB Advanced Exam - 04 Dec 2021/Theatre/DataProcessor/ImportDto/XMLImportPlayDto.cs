using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto;

[XmlType("Play")]
public class XMLImportPlayDto
{
    [XmlElement("Title")]
    [MinLength(4)]
    [MaxLength(50)]
    [Required]
    public string Title { get; set; }

    [XmlElement("Duration")]
    public string Duration { get; set; }

    [XmlElement("Raiting")]
    [Range(0.00,10.00)]
    [Required]
    public float Rating { get; set; }

    [XmlElement("Genre")]
    
    [Required]
    public string Genre { get; set; }

    [XmlElement("Description")]
    [MaxLength(700)]
    [Required]
    public string Description { get; set; }

    [XmlElement("Screenwriter")]
    [MinLength(4)]
    [MaxLength(30)]
    [Required]
    public string Screenwriter { get; set; }
}
