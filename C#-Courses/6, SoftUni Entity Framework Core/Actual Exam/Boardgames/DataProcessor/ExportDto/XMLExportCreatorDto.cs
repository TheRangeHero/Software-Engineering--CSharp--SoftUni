namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Creator")]
public class XMLExportCreatorDto
{
    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; }

    [XmlElement("CreatorName")]
    public string CreatorName { get;set; }

    [XmlArray("Boardgames")]
    public XMLExportBoardgameDto[] Boardgames { get; set; }
}
