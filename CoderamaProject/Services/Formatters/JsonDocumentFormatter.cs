using CoderamaProject.Models;
using System.Text.Json;

namespace CoderamaProject.Services.Formatters
{
    public class JsonDocumentFormatter : IDocumentFormatter
    {
        public string Serialize(Document document) => JsonSerializer.Serialize(document);
    }

}
