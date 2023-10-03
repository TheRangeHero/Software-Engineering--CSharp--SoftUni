using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto;

[XmlType("Coach")]
public class ExportXMLCoachDto
{
    [XmlAttribute("FootballersCount")]
    public int FootballersCount { get; set; }

    [XmlElement("CoachName")]
    public string CoachName { get; set; }

    [XmlArray("Footballers")]
    public ExportXMLFootballerDto[] Footballers { get; set; }
}
