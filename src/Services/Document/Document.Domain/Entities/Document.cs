namespace Document.Domain.Entities
{
    public class Document
    {
        public Guid DocumentId { get; set; }
        public Guid LoanId { get; set; }
        public string DocumentType { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public string FileType { get; set; } = default!;
        public long FileSize { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
