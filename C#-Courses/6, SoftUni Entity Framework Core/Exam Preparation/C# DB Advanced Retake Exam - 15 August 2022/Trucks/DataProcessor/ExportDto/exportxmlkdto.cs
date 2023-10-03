using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class exportxmlkdto
    {
        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; } = null!;

        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlArray("Trucks")]
        public exporttruckdto[] Trucks { get; set; }
    }
}
