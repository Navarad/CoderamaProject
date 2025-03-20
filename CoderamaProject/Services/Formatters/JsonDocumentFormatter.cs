using CoderamaProject.Models;
using System.Text.Json;

namespace CoderamaProject.Services.Formatters
{
    public class JsonDocumentFormatter : IDocumentFormatter
    {
        // TODO: add some validation for the document
        public string Serialize(Document document) => JsonSerializer.Serialize(document);
    }

}
