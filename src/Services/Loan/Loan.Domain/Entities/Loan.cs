using Loan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Domain.Entities
{
    public class Loan
    {
        private Loan()
        {
            
        }

        public Loan(Guid customerId, decimal loanAmount, LoanType loanType, decimal interestRate, int termMonths)
        {
            LoanId = Guid.NewGuid();
            CustomerId = customerId;
            LoanAmount = loanAmount;
            LoanType = loanType;
            InterestRate = interestRate;
            TermMonths = termMonths;
            Status = LoanStatus.Submitted;
            CreatedDate = DateTime.Now;
        }

        public void UpdateStatus(LoanStatus status, string? remarks = null)
        {
            Status = status;
            Remarks = remarks;
            UpdatedDate = DateTime.Now;
        }

        public Guid LoanId { get; private set; }
        public Guid CustomerId { get; private set; }
        public decimal LoanAmount { get; private set; }
        public LoanType LoanType { get; private set; }
        public LoanStatus Status { get; private set; }
        public decimal InterestRate { get; private set; }
        public int TermMonths { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public string? Remarks { get; private set; }
    }
}
