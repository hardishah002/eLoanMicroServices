using Document.API.Models.Request;
using Document.API.Models.Response;
using Document.Application.Features.Documents.Commands;
using Document.Application.Features.Documents.Queries;
using Document.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Document.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromForm] UploadDocumentRequest request)
        {
            if (request.File == null || request.File.Length == 0) return BadRequest("File is required");

            using var stream = request.File.OpenReadStream();

            var command = new UploadDocumentCommand(request.LoanId, request.DocumentType, request.File.FileName,
                Path.GetExtension(request.File.FileName).TrimStart('.'), request.File.Length, stream);

            var documentId = await _mediator.Send(command);

            return Ok(new {DocumentId =  documentId});
        }

        [HttpGet("{loanId}")]
        public async Task<IActionResult> GetDocumentsByLoanId(Guid loanId)
        {
            var query = new GetDocumentByLoadIdQuery(loanId);
            var documents = await _mediator.Send(query);

            var response = documents.Select(a => new DocumentResponse
            { 
                DocumentId = a.DocumentId,
                LoanId = a.LoanId,
                DocumentType = a.DocumentType,
                FileName = a.FileName,
                FileType = a.FileType,
                FileSize = a.FileSize,
                UploadedDate = a.UploadedDate,
            }).ToList();

            return Ok(response);
        }
    }
}

