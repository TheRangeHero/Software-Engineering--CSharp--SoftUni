using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class ExportDTO08UserData
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<ExportDTO08UserWithSoldProducts> USERS { get; set; } = null!;
    }
}
