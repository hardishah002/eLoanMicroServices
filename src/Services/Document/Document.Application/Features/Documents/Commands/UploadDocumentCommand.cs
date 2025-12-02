using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.Documents.Commands
{
    public sealed record UploadDocumentCommand(
        Guid LoanId,
        string DocumentType,
        string FileName,
        string FileType,
        long FileSize,
        Stream FileContent
        ): IRequest<Guid>;
}
