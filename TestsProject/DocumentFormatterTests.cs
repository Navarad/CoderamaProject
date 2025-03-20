using CoderamaProject.Models;
using CoderamaProject.Services.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    public class DocumentFormatterTests
    {
        [Fact]
        public void Serialize_ShouldConvertJsonToXml()
        {
            var formatter = new XmlDocumentFormatter();
            var document = new Document
            {
                Id = "123",
                Tags = new List<string> { "important", "test" },
                Data = new { name = "John", age = 30 }
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

            var document = new Document
            {
                Id = "123",
                Tags = new() { "important", "test" },
                Data = new { key = "value" }
            };

            var jsonString = formatter.Serialize(document);

            Assert.Contains("\"Id\":\"123\"", jsonString);
            Assert.Contains("\"Tags\":[\"important\",\"test\"]", jsonString);
            Assert.Contains("\"key\":\"value\"", jsonString);
        }
    }
}
