using MediatR;
using Notification.Application.Features.EventBus.Loans.Events;
using Notification.Application.Features.Notifications.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.EventBus.Loans.Handlers
{
    public class LoanApplicationSubmittedEventHandler
    {
        private readonly IMediator _mediator;

        public LoanApplicationSubmittedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(LoanApplicationSubmittedEvent evt)
        { 
            await _mediator.Send(new CreateNotificationCommand(evt.CustomerId, evt.Message));
        }
    }
}
