using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Infrastructure.Configurations
{
    public class LoanConfiguration: IEntityTypeConfiguration<Domain.Entities. Loan>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Loan> builder)
        { 
            builder.HasKey(a => a.LoanId);

            builder.Property(a => a.CustomerId).IsRequired();
            builder.Property(a => a.LoanAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(a => a.InterestRate).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(a => a.LoanType).IsRequired().HasConversion<string>().HasMaxLength(50);
            builder.Property(a => a.Status).IsRequired().HasConversion<string>().HasMaxLength(20);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.UpdatedDate).IsRequired(false);
            builder.Property(a => a.Remarks).HasMaxLength(250);

            builder.ToTable("Loans");
        }
    }
}
