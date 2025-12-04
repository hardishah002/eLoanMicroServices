using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Document.Infrastructure.Configurations
{
    public class DocumentConfigurations : IEntityTypeConfiguration<Domain.Entities.Document>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Document> builder)
        {
            builder.HasKey(a => a.DocumentId);
            builder.Property(a => a.DocumentType).IsRequired().HasMaxLength(50);
            builder.Property(a => a.FileName).IsRequired().HasMaxLength(255);
            builder.Property(a => a.FileType).IsRequired().HasMaxLength(10);
            builder.Property(a => a.FileSize).IsRequired();
            builder.Property(a => a.UploadedDate).IsRequired();
        }
    }
}
