using MediatR;

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
