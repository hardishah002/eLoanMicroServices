using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities
{
    public class Notification
    {
        public Guid NotificationId { get; set; }
        public Guid CustomerId { get; set; }
        public string Message { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
    }
}
