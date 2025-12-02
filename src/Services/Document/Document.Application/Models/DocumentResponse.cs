using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
