
using CoderamaProject.Models;

namespace CoderamaProject.Services
{
    public interface IDocumentService
    {
        void SaveDocument(Document document);
        Document GetDocument(string id);
    }
}
