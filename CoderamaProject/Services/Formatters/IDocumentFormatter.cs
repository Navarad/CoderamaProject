using CoderamaProject.Models;

namespace CoderamaProject.Services.Formatters
{
    public interface IDocumentFormatter
    {
        string Serialize(Document document);
    }
}
