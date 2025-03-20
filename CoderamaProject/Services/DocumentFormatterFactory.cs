using CoderamaProject.Services.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace CoderamaProject.Services
{
    public class DocumentFormatterFactory: IDocumentFormatterFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DocumentFormatterFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDocumentFormatter GetFormatter(string contentType)
        {
            switch (contentType)
            {
                case "application/xml":
                    return _serviceProvider.GetRequiredService<XmlDocumentFormatter>();
                case "application/json":
                    return _serviceProvider.GetRequiredService<JsonDocumentFormatter>();
                default:
                    return _serviceProvider.GetRequiredService<JsonDocumentFormatter>();
            };
        }
    }
}
