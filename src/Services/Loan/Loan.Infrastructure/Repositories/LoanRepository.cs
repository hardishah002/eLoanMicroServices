using Loan.Application.Interfaces;
using Loan.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Loan.Infrastructure.Repositories
{
    public class LoanRepository: ILoanRepository
    {
        private readonly LoanDbContext _context;

        public LoanRepository(LoanDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Loan?> GetByIdAsync(Guid loanId)
        {
            return await _context.Loans.FirstOrDefaultAsync(a => a.LoanId == loanId);
        }

        public async Task AddAsync(Domain.Entities.Loan loan)
        { 
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Loan loan)
        { 
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}
