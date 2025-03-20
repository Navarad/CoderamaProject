using CoderamaProject.Models;
using CoderamaProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Xml.Serialization;

namespace CoderamaProject.Controllers
{
    // TODO: we can add custom error handling with custom exceptions to show more information to the client if something goes wrong
    [ApiController]
    [Route("documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IDocumentFormatterFactory _formatterFactory;

        public DocumentsController(IDocumentService documentService, IDocumentFormatterFactory formatterFactory)
        {
            _documentService = documentService;
            _formatterFactory = formatterFactory;
        }

        [HttpPost]
        public IActionResult CreateDocument([FromBody] Document document)
        {
            if (document == null || string.IsNullOrEmpty(document.Id))
                return BadRequest("Invalid document");

            _documentService.SaveDocument(document);
            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDocument(string id, [FromBody] Document document)
        {
            if (document == null || document.Id != id)
                return BadRequest("Invalid document");

            _documentService.SaveDocument(document);
            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json", "application/xml")]
        [Consumes("application/json")]
        public IActionResult GetDocument(string id, [FromHeader(Name = "Accept")] string accept)
        {
            var document = _documentService.GetDocument(id);
            if (document == null)
                return NotFound();

            // TODO: this might be better to be moved to a separate service
            var formatter = _formatterFactory.GetFormatter(accept);
            return Content(formatter.Serialize(document), accept);
        }
    }
}
