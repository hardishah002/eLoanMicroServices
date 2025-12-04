using Document.Application.Common.Exceptions;
using Document.Application.Features.Documents.Commands;
using Document.Application.Interfaces;
using Document.Application.Services;
using MediatR;

namespace Document.Application.Features.Documents.Handlers
{
    public class UploadDocumentCommandHandler: IRequestHandler<UploadDocumentCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileStorageService _service;
        private readonly ILoanServiceClient _loanServiceClient;

        public UploadDocumentCommandHandler(IApplicationDbContext context, IFileStorageService service, ILoanServiceClient loanServiceClient)
        {
            _context = context;
            _service = service;
            _loanServiceClient = loanServiceClient;
        }

       public async Task<Guid> Handle(UploadDocumentCommand request, CancellationToken cancellationToken)
        {
            bool loanExists = await _loanServiceClient.ValidateLoanAsync(request.LoanId, cancellationToken);

            if (!loanExists) throw new NotFoundException($"Loan {request.LoanId} does not exist.");

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
