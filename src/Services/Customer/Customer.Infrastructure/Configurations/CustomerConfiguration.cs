using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Domain.Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
        {
            builder.HasKey(a => a.CustomerId);
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Phone).IsRequired();
            builder.Property(a => a.Address).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.CreatedBy).IsRequired().HasMaxLength(100);

            builder.ToTable("Customers");
        }
    }
}
