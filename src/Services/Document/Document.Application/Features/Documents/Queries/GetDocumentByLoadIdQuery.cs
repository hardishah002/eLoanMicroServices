using Document.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.Documents.Queries
{
    public sealed record GetDocumentByLoadIdQuery(Guid LoanId): IRequest<List<DocumentResponse>>;
}
