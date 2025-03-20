using System.Text.Json;
using System.Xml.Serialization;

namespace CoderamaProject.Models
{
    public class Document
    {
        public string Id { get; set; }
        public List<string> Tags { get; set; } = new();
        [XmlIgnore]
        public object Data { get; set; }
    }
}
