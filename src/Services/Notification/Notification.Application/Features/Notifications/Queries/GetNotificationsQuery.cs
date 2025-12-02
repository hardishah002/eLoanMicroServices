using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Queries
{
    public record GetNotificationsQuery(Guid CustomerId) : IRequest<List<Domain.Entities.Notification>>;
}
