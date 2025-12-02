using MediatR;
using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Queries
{
    public record GetUnreadNotificationsQuery(Guid CustomerId): IRequest<List<Domain.Entities.Notification>>;
}
