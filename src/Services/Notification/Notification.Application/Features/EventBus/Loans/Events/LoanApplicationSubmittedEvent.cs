using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.EventBus.Loans.Events
{
    public class LoanApplicationSubmittedEvent
    {
        public Guid CustomerId { get; set; }
        public Guid LoanId { get; set; }
        public string Message { get; set; } = default!;
    }
}
