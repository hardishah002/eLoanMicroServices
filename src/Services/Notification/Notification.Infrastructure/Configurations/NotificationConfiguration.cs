using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Notification.Infrastructure.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Domain.Entities.Notification>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(x => x.NotificationId);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.CustomerId);
        }
    }
}