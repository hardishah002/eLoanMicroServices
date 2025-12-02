using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Domain.Entities
{
    public class Document
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
