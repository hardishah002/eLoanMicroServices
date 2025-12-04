using Document.Application.Models;
using MediatR;

namespace Document.Application.Features.Documents.Queries
{
    public sealed record GetDocumentByLoadIdQuery(Guid LoanId): IRequest<List<DocumentResponse>>;
}
