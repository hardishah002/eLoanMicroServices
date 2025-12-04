namespace Document.Application.Models
{
    public sealed record DocumentResponse(
        Guid DocumentId,
        Guid LoanId,
        string DocumentType,
        string FileName,
        string FileType,
        long FileSize,
        DateTime UploadedDate
    );
}
