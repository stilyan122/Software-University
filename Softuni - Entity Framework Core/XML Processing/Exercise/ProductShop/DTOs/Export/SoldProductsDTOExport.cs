
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("SoldProducts")]
    public class SoldProductsDTOExport
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public ProductDTOExport2[] Products { get; set; }
    }
}
