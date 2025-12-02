namespace Document.API.Models.Response
{
    public class DocumentResponse
    {
        public Guid DocumentId { get; set; }
        public Guid LoanId { get; set; }
        public string DocumentType { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public string FileType { get; set; } = default!;
        public long FileSize { get; set; } = default!;
        public DateTime UploadedDate { get; set; }
    }
}
