using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Commands
{
    public record MarkNotificationReadCommand(Guid NotificationId): IRequest<Unit>;
}
