using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Application.Interfaces
{
    public interface ILoanRepository
    {
        Task<Domain.Entities.Loan?> GetByIdAsync(Guid loanId);
        Task AddAsync(Domain.Entities.Loan loan);
        Task UpdateAsync(Domain.Entities.Loan loan);
    }
}
