using CoderamaProject.Models;
using Newtonsoft.Json;

using System.Xml;
using System.Xml.Serialization;

namespace CoderamaProject.Services.Formatters
{
    public class XmlDocumentFormatter : IDocumentFormatter
    {
        public string Serialize(Document document)
        {
            if (document?.Data == null)
                throw new ArgumentNullException(nameof(document), "Document or Data cannot be null");

            var jsonString = JsonConvert.SerializeObject(document);
            var xmlDocument = JsonConvert.DeserializeXmlNode(jsonString, "Document");

            if (xmlDocument == null)
                throw new InvalidOperationException("Failed to convert JSON to XML.");

            return xmlDocument.OuterXml;
        }
    }
}
