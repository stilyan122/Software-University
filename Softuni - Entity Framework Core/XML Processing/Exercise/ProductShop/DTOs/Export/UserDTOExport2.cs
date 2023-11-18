using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class UserDTOExport2
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        [XmlElement("age")]
        public int? Age { get; set; }
        public SoldProductsDTOExport SoldProducts { get; set; }

        public XElement ToXElement()
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(UserDTOExport2));
            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, this, namespaces);
                return XElement.Parse(stringWriter.ToString());
            }
        }
    }
}
