using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.UserId);
            builder.Property(a => a.Username).IsRequired().HasMaxLength(50);
            builder.Property(a => a.PasswordHash).IsRequired();
            builder.Property(a => a.Role).IsRequired();

            builder.ToTable("Users");
        }
    }
}
