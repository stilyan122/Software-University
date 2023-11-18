using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("partId")]
    public class PartImportDTO
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
