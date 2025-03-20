using CoderamaProject.Models;
using Newtonsoft.Json;
using System.Text.Json;
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

            // TODO: it might be better to store the file as raw JSON string to avoid conversion here
            var jsonString = JsonConvert.SerializeObject(new
            {
                document.Id,
                document.Tags,
                Data = JsonConvert.DeserializeObject<object>(((JsonElement)document.Data).GetRawText())
            });

            var xmlDocument = JsonConvert.DeserializeXmlNode(jsonString, "Document");

            if (xmlDocument == null)
                throw new InvalidOperationException("Failed to convert JSON to XML.");

            return xmlDocument.OuterXml;
        }
    }
}
