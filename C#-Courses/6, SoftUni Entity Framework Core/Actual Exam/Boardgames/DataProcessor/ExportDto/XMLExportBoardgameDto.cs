﻿namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Boardgame")]
public class XMLExportBoardgameDto
{
    [XmlElement("BoardgameName")]
    public string BoardgameName { get; set; }

    [XmlElement("BoardgameYearPublished")]
    public int BoardgameYearPublished { get; set; }
}
