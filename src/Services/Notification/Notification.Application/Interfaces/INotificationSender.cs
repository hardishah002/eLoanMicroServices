using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Interfaces
{
    public interface INotificationSender
    {
        Task SendAsync(string recipient, string message);
    }
}
