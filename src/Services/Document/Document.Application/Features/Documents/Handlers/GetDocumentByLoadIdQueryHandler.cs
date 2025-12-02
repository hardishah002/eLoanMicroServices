using Document.Application.Features.Documents.Queries;
using Document.Application.Interfaces;
using Document.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.Documents.Handlers
{
    public class GetDocumentByLoadIdQueryHandler : IRequestHandler<GetDocumentByLoadIdQuery, List<DocumentResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetDocumentByLoadIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentResponse>> Handle(GetDocumentByLoadIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Documents
                .Where(a => a.LoanId == request.LoanId)
                .Select(a => new DocumentResponse(
                    a.DocumentId,
                    a.LoanId,
                    a.DocumentType,
                    a.FileName,
                    a.FileType,
                    a.FileSize,
                    a.UploadedDate
                    ))
                .ToListAsync();
        }
    }
}
