using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Commands
{
    public record CreateNotificationCommand(Guid CustomerId, string Message): IRequest<Guid>;
}
