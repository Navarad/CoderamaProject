using System.Collections.Concurrent;
using CoderamaProject.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CoderamaProject.Services.Storages
{
    public class InMemoryDocumentService : IDocumentService
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromHours(1);

        public InMemoryDocumentService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SaveDocument(Document document)
        {
            _cache.Set(document.Id, document, _cacheDuration);
        }

        public Document GetDocument(string id)
        {
            _cache.TryGetValue(id, out Document document);
            return document;
        }
    }
}
