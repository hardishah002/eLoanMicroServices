using FluentValidation;
using Notification.Application.Features.Notifications.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Validators
{
    public class CreateNotificationCommandValidator: AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Message).NotEmpty().MaximumLength(500);
        }
    }
}
