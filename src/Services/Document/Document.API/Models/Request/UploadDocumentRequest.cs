namespace Document.API.Models.Request
{
    public class UploadDocumentRequest
    {
        public Guid LoanId { get; set; }
        public string DocumentType { get; set; } = default!;
        public IFormFile File { get; set; } = default!;
    }
}
