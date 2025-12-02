using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Infrastructure.Persistence
{
    public class LoanDbContext:DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options):base(options)
        {
            
        }

        public DbSet<Domain.Entities.Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoanDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
