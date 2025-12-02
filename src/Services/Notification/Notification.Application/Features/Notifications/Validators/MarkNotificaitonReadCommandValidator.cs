using FluentValidation;
using Notification.Application.Features.Notifications.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Validators
{
    public class MarkNotificaitonReadCommandValidator:AbstractValidator<MarkNotificationReadCommand>
    {
        public MarkNotificaitonReadCommandValidator()
        {
            RuleFor(x => x.NotificationId).NotEmpty();
        }
    }
}
