using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Product")]
    public class ProductDTOExport2
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;
        [XmlElement("price")]
        public double Price { get; set; }
    }
}
