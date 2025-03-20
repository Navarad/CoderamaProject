using CoderamaProject.Models;
using CoderamaProject.Services.Storages;
using Microsoft.Extensions.Caching.Memory;

namespace TestsProject
{
    public class DocumentServiceTests
    {
        [Fact]
        public void SaveDocument_ShouldStoreDocumentInCache()
        {
            var document = new Document { Id = "123", Tags = new() { "test" }, Data = new { key = "value" } };
            var _documentService = new InMemoryDocumentService(new MemoryCache(new MemoryCacheOptions()));

            _documentService.SaveDocument(document);
            var retrievedDocument = _documentService.GetDocument("123");

            Assert.NotNull(retrievedDocument);
            Assert.Equal(document.Id, retrievedDocument.Id);
            Assert.Equal(document.Tags, retrievedDocument.Tags);
        }

        [Fact]
        public void GetDocument_ShouldReturnNull_IfDocumentDoesNotExist()
        {
            var _documentService = new InMemoryDocumentService(new MemoryCache(new MemoryCacheOptions()));

            var retrievedDocument = _documentService.GetDocument("nonexistent");

            Assert.Null(retrievedDocument);
        }

        [Fact]
        public void SaveDocument_ShouldOverrideExistingDocument()
        {
            var _documentService = new InMemoryDocumentService(new MemoryCache(new MemoryCacheOptions()));

            var document1 = new Document { Id = "123", Tags = new() { "first" }, Data = new { key = "value1" } };
            var document2 = new Document { Id = "123", Tags = new() { "second" }, Data = new { key = "value2" } };

            _documentService.SaveDocument(document1);
            _documentService.SaveDocument(document2);
            var retrievedDocument = _documentService.GetDocument("123");

            Assert.NotNull(retrievedDocument);
            Assert.Equal(document2.Tags, retrievedDocument.Tags);
        }
    }
}