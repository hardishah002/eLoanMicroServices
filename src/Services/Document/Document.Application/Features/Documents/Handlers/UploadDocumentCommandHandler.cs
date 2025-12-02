using Document.Application.Features.Documents.Commands;
using Document.Application.Interfaces;
using Document.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.Documents.Handlers
{
    public class UploadDocumentCommandHandler: IRequestHandler<UploadDocumentCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileStorageService _service;

        public UploadDocumentCommandHandler(IApplicationDbContext context, IFileStorageService service)
        {
            _context = context;
            _service = service; 
        }

       public async Task<Guid> Handle(UploadDocumentCommand request, CancellationToken cancellationToken)
        {
            var filePath = await _service.SaveAsync(request.FileContent, request.FileName);

            var document = new Domain.Entities.Document { 
                DocumentId = Guid.NewGuid(),
                LoanId = request.LoanId,
                DocumentType = request.DocumentType,
                FileName = request.FileName,
                FileType = request.FileType,
                FileSize = request.FileSize,
                UploadedDate = DateTime.UtcNow
            };

            _context.Documents.Add(document);
            await _context.SaveChangeAsync(cancellationToken);

            return document.DocumentId;
        }
    }
}
