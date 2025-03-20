using CoderamaProject.Models;
using CoderamaProject.Services.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestsProject
{
    public class DocumentFormatterTests
    {
        [Fact]
        public void Serialize_ShouldConvertJsonToXml()
        {
            var formatter = new XmlDocumentFormatter();

            string jsonString = "{ \"name\": \"John\", \"age\": 30 }";
            var document = new Document
            {
                Id = "123",
                Tags = new List<string> { "important", "test" },
                Data = JsonDocument.Parse(jsonString).RootElement
            };

            string xmlOutput = formatter.Serialize(document);

            Assert.Contains("<Id>123</Id>", xmlOutput);
            Assert.Contains("<name>John</name>", xmlOutput);
            Assert.Contains("<age>30</age>", xmlOutput);
        }

        [Fact]
        public void Serialize_ShouldThrowException_WhenDataIsNull()
        {
            var formatter = new XmlDocumentFormatter();
            var document = new Document { Id = "123", Tags = new List<string>(), Data = null };

            Assert.Throws<ArgumentNullException>(() => formatter.Serialize(document));
        }

        [Fact]
        public void Serialize_ShouldReturnValidJsonString()
        {
            var formatter = new JsonDocumentFormatter();

            string jsonInput = "{ \"key\": \"value\" }";
            var document = new Document
            {
                Id = "123",
                Tags = new() { "important", "test" },
                Data = JsonDocument.Parse(jsonInput).RootElement
            };

            var jsonString = formatter.Serialize(document);

            Assert.Contains("\"Id\":\"123\"", jsonString);
            Assert.Contains("\"Tags\":[\"important\",\"test\"]", jsonString);
            Assert.Contains("\"key\":\"value\"", jsonString);
        }
    }
}
