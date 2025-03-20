using CoderamaProject.Services.Formatters;

namespace CoderamaProject.Services
{
    public interface IDocumentFormatterFactory
    {
        IDocumentFormatter GetFormatter(string contentType);
    }
}
