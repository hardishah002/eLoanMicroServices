using Document.Application.Features.Documents.Commands;
using FluentValidation;

namespace Document.Application.Features.Documents.Validators
{
    public class UploadDocumentCommandValidator : AbstractValidator<UploadDocumentCommand>
    {
        public UploadDocumentCommandValidator()
        {
            RuleFor(x => x.LoanId).NotEmpty();
            RuleFor(x => x.DocumentType).NotEmpty().Must(type => new[] { "ID Proof", "Income Proof", "Address Proof" }.Contains(type))
                .WithMessage("Invalid Document Type. Allowed: ID Proof, Income Proof, Address Proof.");
            RuleFor(x => x.FileName).NotEmpty();
            RuleFor(x => x.FileType).Must(type => new[] { "pdf", "jpg", "png" }.Contains(type.ToLower()))
                .WithMessage("Invalid file type. Allowed: pdf, jpg, png.");
            RuleFor(x => x.FileSize).LessThanOrEqualTo(5 * 1024 * 1024).WithMessage("File size exceeds limit(5 MB).");
        }
    }
}
